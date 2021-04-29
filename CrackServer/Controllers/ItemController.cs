using CrackServer.models;
using CrackServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.ObjectApis;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ObjectToCrackProvider objectManager;
        public ItemController(ObjectToCrackProvider objectManager)
        {
            this.objectManager = objectManager;
        }

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
            ObjectToCrackDefinition objectToCrack = new ObjectToCrackDefinition();
            objectToCrack.objectContent = Encoding.ASCII.GetBytes(hashRequest.hashContent);
            objectToCrack.type = Enum.Parse<ObjectToCrackType>(hashRequest.hashType);
            objectToCrack.objectName = hashRequest.hashName;
            objectManager.addObject(objectToCrack);
        }
    }
}
