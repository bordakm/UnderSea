using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;
        private readonly ITokenService tokenService;
        private readonly ILogger logger;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IConfiguration configuration, ITokenService tokenService, ILogger<AuthController> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.tokenService = tokenService;
            this.logger = logger;
        }        

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            var result = await signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, false, false);
            if (result.Succeeded)
            {
                var user = userManager.Users.SingleOrDefault(user => user.UserName == loginData.UserName);
                return new TokensViewModel()
                {
                    AccessToken = tokenService.CreateAccessToken(user),
                    RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
                };
            }
            throw new Exception("Login attempt failed");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            var user = new User
            {
                UserName = registerData.UserName
            };
            var result = await userManager.CreateAsync(user, registerData.Password);            
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return new TokensViewModel()
                {
                    AccessToken = tokenService.CreateAccessToken(user),
                    RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
                };
            }
            throw new Exception("Registration failed");
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
