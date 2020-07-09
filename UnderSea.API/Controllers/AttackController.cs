using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttackController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Attack([FromBody]AttackDTO attack)
        {
            return NotFound("post error");
        }

        [HttpGet]
        public ActionResult<List<AvailableUnitViewModel>> Get()
        {
            return Ok(new List<AvailableUnitViewModel>());
        }
    }
}
