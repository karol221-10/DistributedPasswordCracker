using CrackerTaskDistributor.api;
using CrackerTaskDistributor.model;
using CrackerTaskDistributor.service;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace CrackerTaskDistributor
{
    class Program
    {
        static void Main(string[] args) 
        {
            var startupParameterResolver = new StartupParameterResolver(args);
            BigInteger counter = new BigInteger(0);
            bool foundPassword = false;
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
    }
}
