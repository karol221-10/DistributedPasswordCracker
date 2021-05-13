using CrackerTaskDistributor.api;
using CrackerTaskDistributor.model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CrackerTaskDistributor.service
{
    class CrackServerProcessorImpl : CrackServerProcessor
    {
        private Uri serverAddress;
        private RestClient restClient;

        public CrackServerProcessorImpl(string serverAddress)
        {
            this.serverAddress = new Uri(serverAddress);
            this.restClient = new RestClient(this.serverAddress);
        }

        public string name => serverAddress.AbsoluteUri;

        public void addDictionary(DictionaryModel file)
        {
            RestRequest request = new RestRequest("/api/dictionary", Method.PUT);
            var json = JsonSerializer.Serialize(file);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = restClient.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error during creating dictionary {0} on server {1}", file.dictionaryName, serverAddress);
            }
        }

        public void addFileToCrack(DictionaryFile file)
        {
            throw new NotImplementedException();
        }

        public void addHashToCrack(Hash hash)
        {
            RestRequest request = new RestRequest("/api/Item/hash", Method.PUT);
            var json = JsonSerializer.Serialize(hash);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = restClient.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error during creating object to crack {0} of type {1} on server {2}", hash.hashName, hash.hashType, hash.hashContent);
            }
        }

        public bool tryCrackFile(string filename, int startPointer, int endPointer)
        {
            throw new NotImplementedException();
        }

        public HackResponse tryCrackHash(HackRequest hackRequest)
        {
            RestRequest request = new RestRequest("/api/Hack", Method.PUT);
            var json = JsonSerializer.Serialize(hackRequest);
            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            var response = restClient.Execute(request);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Error occured during hack password on server {0}", name);
            }
            return JsonSerializer.Deserialize<HackResponse>(response.Content);
        }
    }
}
