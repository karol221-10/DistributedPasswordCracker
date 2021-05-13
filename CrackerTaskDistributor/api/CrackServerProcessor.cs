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
        public string name { get; }
        public void addDictionary(DictionaryModel file);
        public void addFileToCrack(DictionaryFile file);
        public void addHashToCrack(Hash hash);
        public bool tryCrackFile(String filename, int startPointer, int endPointer);
        public HackResponse tryCrackHash(HackRequest hackRequest);
    }
}
