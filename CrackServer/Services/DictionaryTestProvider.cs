using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class DictionaryTestProvider : IDictionaryTestProvider
    {
        public string[] fetchDictionary()
        {
            return File.ReadLines("C:\\Users\\Kamil\\Desktop\\lamacz\\DistributedPasswordCracker\\test_dict.txt").ToArray();  
        }
    }
}
