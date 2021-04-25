using CrackerTaskDistributor.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.api
{
    interface CrackServerProcessor
    {
        public void registerClient(String clientAddress);
        public void addDictionary(Base64EncodedFile file);
        public void addFileToCrack(Base64EncodedFile file);
        public void addHashToCrack(Hash hash);
        public bool tryCrackFile(String filename, int clientId, int startPointer, int endPointer);
        public bool tryCrackHash(String hashName, int clientId, int startPointer, int endPointer);
    }
}
