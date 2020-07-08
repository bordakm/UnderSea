using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.API.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttackSearchController : ControllerBase
    {
        [HttpPost]
        public ActionResult<List<string>> Search([FromBody]string searchPhrase, [FromBody] int page, [FromBody] int itemPerPage)
        {
            return NotFound(new List<string>());
        }
    }
}
