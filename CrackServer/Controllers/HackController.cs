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
        private DictionaryCrackProcessor dictionaryCrackProcessor;

        public HackController(DictionaryCrackProcessor dictionaryCrackProcessor)
        {
            this.dictionaryCrackProcessor = dictionaryCrackProcessor;
        }

        [HttpPut]
        public CrackResult hackPassword(HackRequest hackRequest)
        {
            return dictionaryCrackProcessor.crackPassword(hackRequest.objectName, hackRequest.dictionaryName, hackRequest.startPointer, hackRequest.endPointer);
        }

    }
}
