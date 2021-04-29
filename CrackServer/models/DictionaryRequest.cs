using CrackServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.ObjectApis
{
    public class DictionaryRequest
    {
        public String dictionaryName { get; set; }
        public string[] dictionaryContent { get; set; }
    }
}
