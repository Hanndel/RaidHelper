using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RaidHelper
{
    public class LocalEncrypt
    {
        private string dataToHandle;
        public LocalEncrypt(string Data)
        {
            dataToHandle = Data;
        }
        public string Encrypt()
        {

            //HMACSHA256 Hashs = new HMACSHA256(File.ReadAllBytes("Config/Key.txt"));
            //dataToHandle = BitConverter.ToString(Hashs.ComputeHash(Encoding.Unicode.GetBytes(dataToHandle)));
            return "Password";
        }
    }
}
