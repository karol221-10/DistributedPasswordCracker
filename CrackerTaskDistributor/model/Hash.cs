using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.model
{
    class Hash
    {
        String hashName { get; set; }
        String hashType { get; set; } //TODO: should be enum of allowed values (MD5, SHA1 etc.)
        String hashContent { get; set; }

    }
}
