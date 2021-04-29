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
        public String startPointer { get; set; }
        public String endPointer { get; set; }
        public String method { get; set; }
    }
}
