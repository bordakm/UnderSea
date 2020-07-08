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
        [HttpGet]
        public ActionResult<List<ScoreboardViewModel>> Get()
        {
            return NotFound(new List<ScoreboardViewModel>());
        }

        [HttpPost]
        public ActionResult<string> Search([FromQuery] string searchPhrase)
        {
            return NotFound("post error");
        }
    }
}
