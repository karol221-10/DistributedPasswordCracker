using CrackServer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class DictionaryWordProvider : IWordProvider
    {
        private IDictionaryProvider dictionaryProvider;
        private string dictionaryName;

        public DictionaryWordProvider(IDictionaryProvider dictionaryProvider, string dictionaryName)
        {
            this.dictionaryProvider = dictionaryProvider;
            this.dictionaryName = dictionaryName;
        }

        public string[] getWords(string startPointer, string endPointer)
        {
            int startPointerInt = Int32.Parse(startPointer);
            int endPointerInt = Int32.Parse(endPointer);
            return dictionaryProvider.fetchDictionaryWords(dictionaryName, startPointerInt, endPointerInt);
        }
    }
}
