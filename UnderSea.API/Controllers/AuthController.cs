using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IGameService gameService;
        private readonly ILogger logger;

        public AuthController(SignInManager<User> signInManager, IGameService gameService, ILogger<AuthController> logger)
        {
            this.signInManager = signInManager;
            this.gameService = gameService;
            this.logger = logger;
        }

        [HttpPost("register")]
        public async Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            return await Task.Run(() => new TokensViewModel { AccessToken = "én vagyok az access token", RefreshToken = "én vagyok a refresh token" });
        }

        [HttpPost("login")]
        public async Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, false, false);
                if (result.Succeeded)
                {
                    var user = await signInManager.UserManager.GetUserAsync(HttpContext.User);
                    // sikeres login, mehetnek a tokenek //TODO tokenek
                    return await Task.Run(() => new TokensViewModel { AccessToken = "én vagyok az access token", RefreshToken = "én vagyok a refresh token" });
                }
            }
            throw new Exception("Login attempt failed");
        }

        [HttpPost("logout")]
        [Authorize]
        public async void Logout() // TODO adjunk vissza valamit?
        {
            await signInManager.SignOutAsync();
            // TODO tokenek törlése
        }

        [HttpPost("renew")]
        public async Task<TokensViewModel> RenewToken()
        {
            // TODO tokenek
            return await Task.Run(() => new TokensViewModel { AccessToken = "én vagyok az access token", RefreshToken = "én vagyok a refresh token" });
        }
    }
}
