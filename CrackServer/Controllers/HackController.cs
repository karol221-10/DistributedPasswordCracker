using CrackServer.models;
using CrackServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.ObjectApis;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackController : ControllerBase
    {
        private CrackProcessor dictionaryCrackProcessor;
        private IDictionaryProvider dictionaryProvider;

        public HackController(CrackProcessor dictionaryCrackProcessor, IDictionaryProvider dictionaryProvider)
        {
            this.dictionaryCrackProcessor = dictionaryCrackProcessor;
            this.dictionaryProvider = dictionaryProvider;
        }

        [HttpPut]
        public CrackResult hackPassword(HackRequest hackRequest)
        {
            if(hackRequest.dictionaryName == null)
            {
                return dictionaryCrackProcessor.CrackPassword(hackRequest.objectName, hackRequest.startPointer, hackRequest.endPointer, new BruteForceWordProvider());
            }
            return dictionaryCrackProcessor.CrackPassword(hackRequest.objectName, hackRequest.startPointer, hackRequest.endPointer, new DictionaryWordProvider(dictionaryProvider, hackRequest.dictionaryName));
        }

    }
}
