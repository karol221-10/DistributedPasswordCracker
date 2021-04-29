using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.models
{
    public class ObjectToCrackDefinition
    {
        public string objectName { get; set; }
        public byte[] objectContent { get; set; }
        public ObjectToCrackType type { get; set; }
    }
}
