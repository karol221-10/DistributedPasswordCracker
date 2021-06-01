using CrackServer.IServices;
using CrackServer.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CrackServer.Services
{
    public class CrackProcessor
    {
        private const string TIME_FORMATTER = "{0:00}:{1:00}:{2:00}.{3:00}";
        private ObjectToCrackProvider objectToCrackProvider;

        public CrackProcessor(ObjectToCrackProvider crackObjectProvider)
        {
            this.objectToCrackProvider = crackObjectProvider;
        }

        public CrackResult CrackPassword(string objectName, string startPointer, string endPointer, IWordProvider wordProvider)
        {
            long counter = 0;
            TimeSpan ts;
            string elapsedTime;
            string[] words = wordProvider.getWords(startPointer, endPointer);
            ObjectToCrackDefinition objectToCrack = this.objectToCrackProvider.getObject(objectName);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var crackerPort = new HashCrackerAdapter();
            foreach (string word in words)
            {
                List<string> permutedWords = Permute(word);
                if (word.All(char.IsDigit))
                {
                    //todo: wydzielic sprytnie te dwa ify
                    bool result = crackerPort.tryCrack(word, objectToCrack.objectContent);
                    if (result)
                    {
                        stopWatch.Stop();
                        ts = stopWatch.Elapsed;
                        return new CrackResult(word, (long)ts.TotalMilliseconds, counter);
                    }
                    counter++;
                    continue;
                }
                foreach (string permutedWord in permutedWords)
                {
                    bool result = crackerPort.tryCrack(permutedWord, objectToCrack.objectContent); //TODO: Factory to create proper crackerPort, based on ObjectToCrackDefinition.type
                    if (result)
                    {
                        stopWatch.Stop();
                        ts = stopWatch.Elapsed;
                        return new CrackResult(word, (long)ts.TotalMilliseconds, counter);
                    }
                    counter++;
                }
            }
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format(TIME_FORMATTER, ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            return new CrackResult(null, (long)ts.TotalMilliseconds, counter);
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
