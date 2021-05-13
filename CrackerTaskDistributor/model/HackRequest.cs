using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.model
{
    class HackRequest
    {
        public String objectName { get; set; }
        public String dictionaryName { get; set; }
        public string startPointer { get; set; }
        public string endPointer { get; set; }
    }
}
