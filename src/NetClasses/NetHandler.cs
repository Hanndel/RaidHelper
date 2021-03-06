using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RaidHelper
{
    public class NetHandler
    {
        static readonly HttpClient client = new HttpClient();
        string address;
        public async Task<string> SenderAsync(string user, string password, string hwid)
        {

            byte[] bytes = new byte[1024];
            address = await PublicIp();
            IPAddress ipAddress = IPAddress.Parse(await GitServer());
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 60099);

            Socket sender = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(remoteEP);


            Console.WriteLine("Socket connected to {0}",
            sender.RemoteEndPoint.ToString());
            RequestForm request = new RequestForm
            {
                kindOf = "Auth",
                user = user,
                password = CreateMD5(password),
                hwid = hwid,
                ip = address,
            };
            string stringToSend = JsonSerializer.Serialize(request);
            byte[] msg = Encoding.ASCII.GetBytes(stringToSend);
            Console.WriteLine(stringToSend);

            int bytesSent = sender.Send(msg);

            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        private async Task<string> PublicIp()
        {
            HttpResponseMessage response = await client.GetAsync("https://www.myexternalip.com/raw");
            response.EnsureSuccessStatusCode();
            address = await response.Content.ReadAsStringAsync();
            return address;
        }
        private async Task<string> GitServer()
        {

            byte[] IpData;
            byte[] IvData;
            HttpResponseMessage IpResponse = await client.GetAsync("");
            IpResponse.EnsureSuccessStatusCode();
            HttpResponseMessage IvResponse = await client.GetAsync("");
            IvResponse.EnsureSuccessStatusCode();
            IpData = await IpResponse.Content.ReadAsByteArrayAsync();
            IvData = await IvResponse.Content.ReadAsByteArrayAsync();
            return GetServerIp(IpData, IvData);
        }
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
        private string GetServerIp(byte[] Data, byte[] Iv)
        {
            String ServerIp;
            Aes AES = Aes.Create();
            AES.Key = File.ReadAllBytes("Config/Key.txt");
            AES.IV = Iv;
            AES.Padding = PaddingMode.None;
            ICryptoTransform decryptor = AES.CreateDecryptor(AES.Key, AES.IV);
            using (MemoryStream msDecrypt = new MemoryStream(Data))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        ServerIp = srDecrypt.ReadToEnd();
                    }
                }
            }
            int position = ServerIp.IndexOf("P");
            ServerIp = position > -1 ? ServerIp.Substring(0, ServerIp.IndexOf("P")) : ServerIp;
            return ServerIp;
        }
    }
}
