using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.ObjectApis
{
    public class HackResponse
    {
        public Boolean done { get; set; }
        public String foundPassword { get; set; }

        public long checkedPasswords;
        public long time;
    }
}
