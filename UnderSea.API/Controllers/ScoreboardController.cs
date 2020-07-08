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
    public class ScoreboardController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ScoreboardDTO>> Get()
        {
            return NotFound(new List<ScoreboardDTO>());
        }

        [HttpPost]
        public ActionResult<string> Post(string searchPhase)
        {
            return NotFound("post error");
        }
    }
}
