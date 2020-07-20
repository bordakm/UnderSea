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
        public async Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            return await authService.Login(loginData);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            return await authService.Register(registerData);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            await authService.Logout(User);
        }

        [HttpPost("renew")]
        [AllowAnonymous]
        public async Task<TokensViewModel> RenewToken([FromBody] RefreshTokenDTO tokenDTO)
        {
            return await authService.RenewToken(tokenDTO);
        }
    }
}
