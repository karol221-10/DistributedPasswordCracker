using CrackServer.IServices;
using CrackServer.models;
using CrackServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.ObjectApis;

namespace WebApplication3.Controllers
{
    [Route("api/dictionary")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
       private readonly IDictionaryTestProvider dictionaryService;

        public DictionaryController(IDictionaryTestProvider dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }

        [HttpPut]
        public void PostDictionary(DictionaryRequest request)
        {
            //TODO: Add dictionary from dictionaryrequest to supported dictionaries
        }

        [HttpGet]
        [Route("/test")]
        public string testDictionary()
        {
            string password;
            byte[] tmpSource;
            byte[] tmpHash;
            password = "12345678";

            //Create a byte array from source data.
            tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);


            DictionaryProvider dictProvider = new DictionaryProvider(dictionaryService.fetchDictionary());
            CrackObjectProvider crackObjectProvider = new CrackObjectProvider(tmpHash);
            ICrackerPort cracker = new HashCrackerAdapter();

            DictionaryCrackProcessor dictionaryCrackProcessor = new DictionaryCrackProcessor(crackObjectProvider, dictProvider, cracker);

            CrackResult crackResult =  dictionaryCrackProcessor.crackPassword(0, 200000);

            Console.WriteLine("Numer złamanego hasła: " + crackResult.CrackedPassowrdCounter);
            Console.WriteLine("Złamane hasło: " + crackResult.CrackedPassword);
            Console.WriteLine("Czas trwania łamania hasła: " + crackResult.Duratrion);

            return "test się zakończył";
        }
    }
}
