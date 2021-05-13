using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.model
{
    class HackResponse
    {
        public string crackedPassword { get; set; }

        public long duration { get; set; }

        public long crackedPasswordCounter { get; set; }
    }
}
