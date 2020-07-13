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
        public Task Register([FromBody] RegisterDTO registerData)
        {
            return null;
        }

        [HttpPost("login")]
        public async Task<MainPageViewModel> Login([FromBody] LoginDTO loginData)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, false, false);
                if (result.Succeeded)
                {
                    // TODO tokenek
                    var user = signInManager.UserManager.GetUserAsync(HttpContext.User);
                    return await gameService.GetMainPage(user.Id);
                }
            }
            throw new Exception("Login attempt failed");
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            await signInManager.SignOutAsync();
            // TODO tokenek
        }

        [HttpPost("renew")]
        public Task RenewToken()
        {
            return null;
        }
    }
}
