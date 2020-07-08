using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.API.DTO;
using UnderSea.API.ViewModels;

namespace UnderSea.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpgradeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UpgradeViewModel>> Get()
        {
            return NotFound(new List<UpgradeViewModel>());
        }

        [HttpPost]
        public ActionResult<string> Research([FromBody]int id)
        {
            return NotFound("post error");
        }
    }
}
