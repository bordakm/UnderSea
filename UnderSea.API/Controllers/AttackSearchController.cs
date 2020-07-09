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
    public class AttackSearchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<string>> Search([FromBody] SearchDTO search)
        {
            return NotFound(new List<string>());
        }
    }
}
