using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.model
{
    class Hash
    {
        public string hashName { get; set; }
        public string hashType { get; set; } //TODO: should be enum of allowed values (MD5, SHA1 etc.)
        public string hashContent { get; set; }

    }
}
