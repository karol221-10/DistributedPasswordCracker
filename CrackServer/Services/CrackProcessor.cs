using CrackServer.IServices;
using CrackServer.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            List<string> specialCharsCombinations = generate();
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
                        return new CrackResult(permutedWord, (long)ts.TotalMilliseconds, counter);
                    }
                    counter++;

                    for (int i = 1;i <= 9999; i++){
                     string permutedWordWithDigit = permutedWord + i;
                      Console.WriteLine(permutedWordWithDigit);
                        bool result2 = crackerPort.tryCrack(permutedWordWithDigit, objectToCrack.objectContent); //TODO: Factory to create proper crackerPort, based on ObjectToCrackDefinition.type
                    if (result2)
                      {
                          stopWatch.Stop();
                        ts = stopWatch.Elapsed;
                            return new CrackResult(permutedWordWithDigit, (long)ts.TotalMilliseconds, counter);
                      }
                      counter++;
                      foreach (string specialChar in specialCharsCombinations)
                       {
                          string permutedWordWithDigitWithChars = permutedWordWithDigit + specialChar;
                         Console.WriteLine(permutedWordWithDigitWithChars);
                         bool result3 = crackerPort.tryCrack(permutedWordWithDigitWithChars, objectToCrack.objectContent); //TODO: Factory to create proper crackerPort, based on ObjectToCrackDefinition.type
                        if (result3)
                        {
                               stopWatch.Stop();
                               ts = stopWatch.Elapsed;
                             return new CrackResult(permutedWordWithDigitWithChars, (long)ts.TotalMilliseconds, counter);
                          }
                           counter++;
                      }
                     
                    }
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


        public static List<string> permuteSpecialChars(int r1)
        {
            char[] values = { '!', '@', '#', '$', '%', '^', '&', '*' };
            int n = values.Length;
            int r = r1;
            int[] output = new int[r];
            List<string> results = new List<string>();

            for (int numIterations = 0; numIterations < Math.Pow(n, r); numIterations++)
            {
                results.Add(  print(values, r, output));
                int index = 0;
                while (index < r)
                {
                    if (output[index] < n - 1)
                    {
                        output[index]++;
                        break;
                    }
                    else
                    {
                        output[index] = 0;
                    }
                    index++;
                }
            }
            return results;
        }

        private List<string> generate()
        {
            List<string> concatArray = new List<string>();
            for (int i = 1; i <= 7; i++)
            {
                concatArray.AddRange( permuteSpecialChars(i));
            }
            return concatArray;
        }

        private static String print(char[] values, int r, int[] output)
        {
            String result = "";
            while (r-- > 0)
            {
                result += values[output[r]];
            }
            return result;
        }

    }
}

