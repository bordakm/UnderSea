using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.API.DTO;
using UnderSea.API.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BuildingInfoViewModel>> Get()
        {
            return NotFound(new List<BuildingInfoViewModel>());
        }

        [HttpPost]
        public ActionResult<string> Buy([FromBody]int id)
        {
            return NotFound("post error");
        }
    }
}
