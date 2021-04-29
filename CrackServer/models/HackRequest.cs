using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.ObjectApis
{
    public class HackRequest 
    {
        public String objectName { get; set; }

        public String dictionaryName { get; set; }
        public int startPointer { get; set; }
        public int endPointer { get; set; }
    }
}
