using System;

namespace CrackerTaskDistributor
{
    class Program
    {
        static void Main(string[] args)
        {
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
    }
}
