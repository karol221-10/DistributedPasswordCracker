using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class DictionaryTestProvider : IDictionaryProvider
    {
        private Dictionary<string, List<string>> dictionaryMap = new Dictionary<string, List<string>>();

        public void addDictionary(string dictionaryName, string[] dictionaryContent)
        {
            Console.WriteLine("Added dictionary {0}", dictionaryName);
            dictionaryMap.Remove(dictionaryName);
            dictionaryMap.Add(dictionaryName, dictionaryContent.OfType<string>().ToList());
        }

        public string[] fetchDictionaryWords(string dictionaryName, int startPointer, int endPointer)
        {
            List<string> result;
            dictionaryMap.TryGetValue(dictionaryName,out result);
            return new ArraySegment<string>(result.ToArray(), startPointer, endPointer).ToArray();
        }
    }
}
