using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.API.DTO;

namespace UnderSea.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpgradeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UpgradeDTO>> Get()
        {
            return NotFound(new List<UpgradeDTO>());
        }

        [HttpPost]
        public ActionResult<string> Post(int id)
        {
            return NotFound("post error");
        }
    }
}
