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
    public class ScoreboardController : ControllerBase
    {

        [HttpPost]
        public ActionResult<List<ScoreboardViewModel>> Search([FromBody] string searchPhrase, [FromBody] int page, [FromBody] int itemPerPage)
        {
            return NotFound(new List<ScoreboardViewModel>());
        }
    }
}
