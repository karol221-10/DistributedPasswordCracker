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
            byte[] tmpWordByte;
            byte[] tmpWordHash;

            tmpWordByte = ASCIIEncoding.ASCII.GetBytes(dictWord);
            tmpWordHash = new MD5CryptoServiceProvider().ComputeHash(tmpWordByte);
         
            return passwordHashed.SequenceEqual(tmpWordHash);
        }
    }
}
