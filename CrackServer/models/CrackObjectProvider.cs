using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class CrackObjectProvider
    {
        private byte[] hashContent;

        public CrackObjectProvider(byte[] hashContent)
        {
            this.hashContent = hashContent;
        }

        public byte[] HashContent { get => hashContent; set => hashContent = value; }
    }
}
