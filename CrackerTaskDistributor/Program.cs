using CrackerTaskDistributor.api;
using CrackerTaskDistributor.model;
using CrackerTaskDistributor.service;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;
using System.Threading;

namespace CrackerTaskDistributor
{
    class Program
    {
        private static BigInteger counter = new BigInteger(0);
        private static Mutex mut = new Mutex();
        private static Mutex crackedPasswordCounterMutex = new Mutex();
        private static bool foundPassword = false;
        private static long crackedPasswordInLastMinute = 0;
        static void Main(string[] args) 
        {
            var startupParameterResolver = new StartupParameterResolver(args);
            List<CrackServerProcessor> crackServerProcessors = new List<CrackServerProcessor>();
            foreach(string server in startupParameterResolver.crackServerAddresses)
            {
                CrackServerProcessor crackServerProcessor = new CrackServerProcessorImpl(server);
                crackServerProcessors.Add(crackServerProcessor);
                crackServerProcessor.addDictionary(startupParameterResolver.dictionaryModel);
                Console.WriteLine("Register dictionary in server {0}", server);
                crackServerProcessor.addHashToCrack(addObjectToCrack(startupParameterResolver.objectToCrack, crackServerProcessor));
                Console.WriteLine("Registered object to crack in server {0}", server);
            }

            Thread[] threads = new Thread[crackServerProcessors.Count + 1];
            for(int i = 0; i < threads.Length - 1; i++)
            {
                threads[i] = new Thread(tryCrack);
                threads[i].Start(new object[] {
                    startupParameterResolver.objectToCrack.name,
                        startupParameterResolver.dictionaryModel.dictionaryName,
                        startupParameterResolver.blockSize,
                        crackServerProcessors[i]
                    });
            }
            threads[crackServerProcessors.Count] = new Thread(countPerformance);
            threads[crackServerProcessors.Count].Start();
            for(int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }
            // args
            // --serversFile {filename} - file containing list of servers {json}
            // --dictionaryFile {filename} - file containg list of dictionaries {one in each word}
            // --fileToCrack {filename} - file to crack 
            // --blockSize {number} - number of passwords verified in one iteration
            
            /* Algorithm
             * var dictionaryName = StartupParameterResolver.getDictionaryFilename()
             * var fileToCrack = StartupParameterResolver.getFileToCrackFilename()
             * var clients = StartupParameterResolver.getCrackServerAddresses()
             * var dictionary = FileProvider.readDictionary()
             * var fileToCrack = FileProvider.readFileToCrack()
             * for each client generate start and end pointers. Then {
             *     var result = crackServerProcessor.tryCrackFile(fileToCrack, i, startPointer[i], endPointer[i]);
             *     if result.success == true then print password, execution time and kill program
             * }
             */
        }

        private static Hash addObjectToCrack(ObjectToCrack objectToCrack, CrackServerProcessor crackServerProcessor)
        {
            var hash = new Hash();
            hash.hashName = objectToCrack.name;
            hash.hashType = objectToCrack.type.ToString();
            hash.hashContent = objectToCrack.content;
            return hash;
        }

        private static void countPerformance()
        {
            while(foundPassword == false)
            {
                Thread.Sleep(60000);
                crackedPasswordCounterMutex.WaitOne();
                Console.WriteLine("Performance: {0} passwords/sec", crackedPasswordInLastMinute);
                crackedPasswordInLastMinute = 0;
                crackedPasswordCounterMutex.ReleaseMutex();
            }
        }

        private static void tryCrack(object args)
        {
            while (foundPassword == false)
            {
                object[] array = args as object[];
                string objectToCrackName = (string)array[0];
                string dictionaryName = (string)array[1];
                int chunkSize = (int)array[2];
                CrackServerProcessor processor = (CrackServerProcessor)array[3];
                mut.WaitOne();
                string startValue = counter.ToString();
                counter += chunkSize;
                string endValue = counter.ToString();
                mut.ReleaseMutex();
                HackRequest request = new HackRequest();
                request.startPointer = startValue;
                request.endPointer = endValue;
                request.objectName = objectToCrackName;
                request.dictionaryName = dictionaryName;
                Console.WriteLine("Request of hack password: {0} from dictionary range {1} to {2}", processor.name, startValue, endValue);
                var response = processor.tryCrackHash(request);
                Console.WriteLine("Received response from {0} {1}", processor.name, JsonSerializer.Serialize(response));
                crackedPasswordCounterMutex.WaitOne();
                crackedPasswordInLastMinute += response.crackedPasswordCounter;
                crackedPasswordCounterMutex.ReleaseMutex();
            }

        }
    }
}
