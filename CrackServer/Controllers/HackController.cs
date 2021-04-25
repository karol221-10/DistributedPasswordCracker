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
        [HttpPut]
        public HackResponse hackPassword(HackRequest hackRequest)
        {
            //TODO: hack password logic 
            return new HackResponse();
        }

    }
}
