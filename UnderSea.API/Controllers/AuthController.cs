using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            return authService.Login(loginData);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            return authService.Register(registerData);
        }

        [HttpPost("logout")]
        [Authorize]
        public Task Logout()
        {
            return authService.Logout(User);
        }

        [HttpPost("renew")]
        [AllowAnonymous]
        public Task<TokensViewModel> RenewToken([FromBody] RefreshTokenDTO tokenDTO)
        {
            return authService.RenewToken(tokenDTO);
        }
    }
}
