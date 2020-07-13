using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger logger;

        public AuthController(ILogger<AuthController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("/register")]
        public ActionResult<string> Register([FromBody] RegisterDTO registerData)
        {
            return NotFound("post error");
        }

        [HttpPost("/login")]
        public ActionResult<string> Login([FromBody] LoginDTO loginData)
        {
            return NotFound("post error");
        }

        [HttpPost("/logout")]
        public ActionResult Logout()
        {
            return BadRequest("Not implemented");
        }
    }
}
