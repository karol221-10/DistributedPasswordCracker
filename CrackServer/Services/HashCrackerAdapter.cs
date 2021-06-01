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
            string encodedHash = Encoding.Default.GetString(passwordHashed);
            return dictWord.Equals(encodedHash);
        }
    }
}
