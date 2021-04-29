using CrackServer.IServices;
using CrackServer.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class DictionaryCrackProcessor
    {
        private const string TIME_FORMATTER = "{0:00}:{1:00}:{2:00}.{3:00}";
        private ObjectToCrackProvider objectToCrackProvider;

        private IDictionaryTestProvider dictionaryTestProvider;

        public DictionaryCrackProcessor(ObjectToCrackProvider crackObjectProvider, IDictionaryTestProvider dictionaryProvider)
        {
            this.objectToCrackProvider = crackObjectProvider;
            this.dictionaryTestProvider = dictionaryProvider;
        }

        public CrackResult crackPassword(string objectName, string dictionaryName, int startPointer, int endPointer)
        {
            long counter = 0;
            TimeSpan ts;
            string elapsedTime;
            string[] words = this.dictionaryTestProvider.fetchDictionaryWords(dictionaryName, startPointer, endPointer);
            ObjectToCrackDefinition objectToCrack = this.objectToCrackProvider.getObject(objectName);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var crackerPort = new HashCrackerAdapter();
            foreach (string word in words)
            {
                List<string> permutedWords = Permute(word);

                foreach (string permutedWord in permutedWords)
                {
                    Console.WriteLine(permutedWord);
                    bool result = crackerPort.tryCrack(permutedWord, objectToCrack.objectContent); //TODO: Factory to create proper crackerPort, based on ObjectToCrackDefinition.type
                    if (result)
                    {
                        stopWatch.Stop();
                        ts = stopWatch.Elapsed;
                        elapsedTime = String.Format(TIME_FORMATTER, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        return new CrackResult(word, elapsedTime, counter);
                    }
                    counter++;
                }
            }
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format(TIME_FORMATTER, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return new CrackResult(null, elapsedTime, counter);
        }

        static List<string> Permute(String input)
        {
            int n = input.Length;
            int max = 1 << n;
            List<string> permutedWords = new List<string>();
            char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            input = input.ToLower();
            for (int i = 0; i < max; i++)
            {
                char[] combination = input.ToCharArray();
                for (int j = 0; j < n; j++)
                {
                    if (numbers.Contains(combination[j]))
                        continue;
                    if (((i >> j) & 1) == 1)
                        combination[j] = (char)(combination[j] - 32);
                    

                }
                permutedWords.Add(new string(combination));
            }

            return permutedWords;
        }
    }
}
