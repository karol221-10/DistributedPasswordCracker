using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.models
{
    public class DictionaryProvider
    {
        private String[] words;

        public DictionaryProvider(string[] words)
        {
            this.Words = words;
        }

        public string[] GetWords(int startPointer, int endPointer)
        {
            return new ArraySegment<string>(this.words, startPointer, endPointer).ToArray();
        }

        public string[] Words { get => words; set => words = value; }
    }
}
