using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public interface IDictionaryTestProvider
    {

        string[] fetchDictionaryWords(string dictionaryName, int startPointer, int endPointer);
        void addDictionary(string dictionaryName, string[] dictionaryContent);
    }
}
