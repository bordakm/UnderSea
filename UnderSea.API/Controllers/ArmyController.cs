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
    public class ArmyController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UnitDTO>> Get()
        {
            return NotFound(new List<UnitDTO>());
        }

        [HttpPost]
        public ActionResult<string> Post(List<UnitPurchaseDTO> list)
        {
            return NotFound("post error");
        }
    }
}
