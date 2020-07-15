using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly ITokenService tokenService;
        private readonly IGameService gameService;
        private readonly ILogger logger;

        public AuthController(SignInManager<User> signInManager, ITokenService tokenService, IGameService gameService, ILogger<AuthController> logger)
        {
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this.gameService = gameService;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            return await Task.Run(() => new TokensViewModel { AccessToken = "én vagyok az access token", RefreshToken = "én vagyok a refresh token" });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await signInManager.UserManager.FindByNameAsync(loginData.UserName);
                    return new TokensViewModel()
                    {
                        AccessToken = tokenService.CreateAccessToken(user),
                        RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
                    };
                }
            }
            throw new Exception("Login attempt failed");
        }

        [HttpPost("logout")]
        [Authorize]
        public async void Logout() // TODO adjunk vissza valamit?
        {
            /*var user = HttpContext.User;
            tokenService.RemoveRefreshTokenAsync(user);
            signInManager.SignOutAsync();*/ 
        }

        [HttpPost("renew")]
        public async Task<TokensViewModel> RenewToken()
        {
            // TODO tokenek
            return await Task.Run(() => new TokensViewModel { AccessToken = "én vagyok az access token", RefreshToken = "én vagyok a refresh token" });
        }
    }
}
