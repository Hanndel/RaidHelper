﻿using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.Http;
using System.Text;

namespace RaidHelper
{
    public class NetHandler
    {
        static readonly HttpClient client = new HttpClient();
        string address;
        public string Sender(string user, string password, string hwid)
        {
            byte[] bytes = new byte[1024];
            IPAddress ipAddress = IPAddress.Parse("82.213.222.152");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 65432);

            Socket sender = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);

            Console.WriteLine("Socket connected to {0}",
            sender.RemoteEndPoint.ToString());
            Console.WriteLine(CreateMD5(password));
            PublicIp();
            byte[] msg = Encoding.ASCII.GetBytes(user + "," + CreateMD5(user) + "," + CreateMD5(password) + "," + address + "," + hwid);

            int bytesSent = sender.Send(msg);

            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));

            sender.Shutdown(SocketShutdown.Both);
            sender.Close();

            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }

        private async void PublicIp()
        {
            HttpResponseMessage response = await client.GetAsync("http://checkip.dyndns.org/");
            response.EnsureSuccessStatusCode();
            address = await response.Content.ReadAsStringAsync();

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
    }
}