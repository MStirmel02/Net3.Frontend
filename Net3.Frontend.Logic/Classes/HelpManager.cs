using Net3.Frontend.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.Logic.Classes
{
    public class HelpManager
    {
        public static string HashSha256(string source)
        {
            string hashValue = "";

            byte[] data;
            using (SHA256 sha256 = SHA256.Create())
            {
                data = sha256.ComputeHash(Encoding.UTF8.GetBytes(source));
            }

            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            hashValue = s.ToString();
            return hashValue;
        }
    }
}
