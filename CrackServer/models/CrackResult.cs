using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.models
{
    public class CrackResult
    { 
        private String crackedPassword;

        private String duratrion;

        private long crackedPassowrdCounter;

        public CrackResult(string crackedPassword, string duratrion, long crackedPassowrdCounter)
        {
            this.CrackedPassword = crackedPassword;
            this.Duratrion = duratrion;
            this.CrackedPassowrdCounter = crackedPassowrdCounter;
        }

        public string CrackedPassword { get => crackedPassword; set => crackedPassword = value; }
        public string Duratrion { get => duratrion; set => duratrion = value; }
        public long CrackedPassowrdCounter { get => crackedPassowrdCounter; set => crackedPassowrdCounter = value; }
    }
}
