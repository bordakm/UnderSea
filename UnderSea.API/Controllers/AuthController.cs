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
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [Route("/register")]
        public ActionResult<string> Register([FromBody] RegisterDTO registerData)
        {
            return NotFound("post error");
        }
        [HttpPost]
        [Route("/login")]
        public ActionResult<string> Login([FromBody] LoginDTO loginData)
        {
            return NotFound("post error");
        }

        [HttpPost]
        [Route("/logout")]
        public ActionResult Logout()
        {
            return BadRequest("Not implemented");
        }
    }
}
