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
        public ActionResult<UpgradeDTO> Get()
        {
            return NotFound();
        }

        [HttpPost]
        public ActionResult<string> Post(int id)
        {
            return NotFound("post error");
        }
    }
}
