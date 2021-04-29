using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.IServices
{
    public interface ICrackerPort
    {
       Boolean tryCrack(string dictWord, byte[] passwordHashed);
    }
}
