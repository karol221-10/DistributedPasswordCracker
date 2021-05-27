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
       private readonly IDictionaryProvider dictionaryService;

        public DictionaryController(IDictionaryProvider dictionaryService)
        {
            this.dictionaryService = dictionaryService;
        }

        [HttpPut]
        public void PostDictionary(DictionaryRequest request)
        {
            dictionaryService.addDictionary(request.dictionaryName, request.dictionaryContent);
        }
    }
}
