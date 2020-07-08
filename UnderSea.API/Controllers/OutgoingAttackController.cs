using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.API.DTO;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutgoingAttackController : ControllerBase
    {
        [HttpGet]
        public ActionResult<OutgoingAttackDTO> Get()
        {
            return NotFound();
        }
    }
}
