using CrackerTaskDistributor.api;
using CrackerTaskDistributor.constants;
using CrackerTaskDistributor.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.service
{
    class StartupParameterResolver
    {
        public int blockSize { get; } = 1000;
        public List<string> crackServerAddresses { get; }
        public DictionaryModel dictionaryModel { get; }
        public ObjectToCrack objectToCrack { get; }
        public StartupParameterResolver(string[] commandLineParams)
        {
            objectToCrack = new ObjectToCrack();
            for(int i = 0; i < commandLineParams.Length; i++)
            {
                if(CommandLineParameterNames.SERVER_LIST_PARAMETER.Equals(commandLineParams[i])) {
                    crackServerAddresses = ReadServerAddressesFromFile(commandLineParams[i + 1]);
                }
                if(CommandLineParameterNames.DICTIONARY_FILE_PARAMETER.Equals(commandLineParams[i])) {
                    dictionaryModel = ReadDictionary(commandLineParams[i + 1]);
                }
                if(CommandLineParameterNames.OBJECT_TO_CRACK_NAME_PARAMETER.Equals(commandLineParams[i])) {
                    objectToCrack.name = commandLineParams[i + 1];
                }
                if(CommandLineParameterNames.OBJECT_TO_CRACK_CONTENT_PARAMETER.Equals(commandLineParams[i]))
                {
                    objectToCrack.content = commandLineParams[i + 1];
                }
                if(CommandLineParameterNames.OBJECT_TO_CRACK_TYPE_PARAMETER.Equals(commandLineParams[i])) {
                    objectToCrack.type = (ObjectToCrackType) Enum.Parse(typeof(ObjectToCrackType), commandLineParams[i + 1]);
                }
                if(CommandLineParameterNames.OBJECT_TO_CRACK_METHOD_PARAMETER.Equals(commandLineParams[i])) {
                    objectToCrack.crackMethod = (ObjectToCrackMethod)Enum.Parse(typeof(ObjectToCrackMethod), commandLineParams[i + 1]);
                }
            }
            ValidateResolvedParameters();
        }

        private List<string> ReadServerAddressesFromFile(string filename)
        {
            using(StreamReader r = new StreamReader(filename))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<string>>(json);
            }
        }

        private DictionaryModel ReadDictionary(string filename)
        {
            List<string> words = new List<string>();
            using(StreamReader r = new StreamReader(filename))
            {
                while(!r.EndOfStream)
                {
                    words.Add(r.ReadLine());
                }
            }
            DictionaryModel dictionaryModel = new DictionaryModel();
            dictionaryModel.dictionaryName = filename;
            dictionaryModel.dictionaryContent = words.ToArray();
            return dictionaryModel;
        }
        private void ValidateResolvedParameters()
        {
            if(crackServerAddresses == null)
            {
                DisplayAndThrowException(CommandLineParameterNames.SERVER_LIST_PARAMETER);
            }
            if(objectToCrack.name == null)
            {
                DisplayAndThrowException(CommandLineParameterNames.OBJECT_TO_CRACK_NAME_PARAMETER);
            }
            if(objectToCrack.content == null)
            {
                DisplayAndThrowException(CommandLineParameterNames.OBJECT_TO_CRACK_CONTENT_PARAMETER);
            }
            if(objectToCrack.type == ObjectToCrackType.UNDEFINED)
            {
                DisplayAndThrowException(CommandLineParameterNames.OBJECT_TO_CRACK_TYPE_PARAMETER);
            }

        }

        private void DisplayAndThrowException(string parameterName)
        {
            Console.WriteLine("Parameter {0} was incorrect", parameterName);
            throw new ArgumentException();
        }
    }
}
