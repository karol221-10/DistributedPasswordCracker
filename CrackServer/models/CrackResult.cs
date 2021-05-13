using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.models
{
    public class CrackResult
    {
        public CrackResult(string crackedPassword, long duration, long crackedPasswordCounter)
        {
            this.crackedPassword = crackedPassword;
            this.duration = duration;
            this.crackedPasswordCounter = crackedPasswordCounter;
        }

        public string crackedPassword { get; set; }

        public long duration { get; set; }

        public long crackedPasswordCounter { get; set; }
    }
}
