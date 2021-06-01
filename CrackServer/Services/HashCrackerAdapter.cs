using CrackServer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class HashCrackerAdapter : ICrackerPort
    {
        public bool tryCrack(string dictWord, byte[] passwordHashed)
        {
            var dictWordHashed = Encoding.ASCII.GetBytes(CreateMD5(dictWord));
            return passwordHashed.SequenceEqual(dictWordHashed);
        }

        private string CreateMD5(string input)
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