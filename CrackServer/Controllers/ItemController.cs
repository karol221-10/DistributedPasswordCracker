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
    public class ItemController : ControllerBase
    {
        [HttpPut]
        [Route("/api/[controller]/file")]
        public void postFile(FileRequest file)
        {
            //TODO: save file in local storage (in memory or as file on the disk). 
        }

        [HttpPut]
        [Route("/api/[controller]/hash")]
        public void postHash(HashRequest hashRequest)
        {
            //TODO: save hash to crack in local storage
        }
    }
}
