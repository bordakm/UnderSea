using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IGameService gameService;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService,
            IUserService userService, IGameService gameService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.userService = userService;
            this.gameService = gameService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<TokensViewModel> Login([FromBody] LoginDTO loginData)
        {
            var result = await signInManager.PasswordSignInAsync(loginData.UserName, loginData.Password, false, false);
            if (result.Succeeded)
            {
                var user = await userManager.Users.SingleAsync(user => user.UserName == loginData.UserName);
                return new TokensViewModel()
                {
                    AccessToken = tokenService.CreateAccessToken(user),
                    RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
                };
            }
            throw new HttpResponseException { Status = 400, Value = "Login failed" };
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<TokensViewModel> Register([FromBody] RegisterDTO registerData)
        {
            var user = await userService.CreateUserAsync(registerData);
            var result = await userManager.CreateAsync(user, registerData.Password);
            if (result.Succeeded)
            {
                await gameService.CalculateRankingsAsync();
                await signInManager.SignInAsync(user, false);
                return new TokensViewModel()
                {
                    AccessToken = tokenService.CreateAccessToken(user),
                    RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
                };
            }
            throw new HttpResponseException { Status = 400, Value = result.Errors };
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            var user = await userManager.GetUserAsync(User);
            await signInManager.SignOutAsync();
            await tokenService.RemoveRefreshTokenAsync(user);
        }

        [HttpPost("renew")]
        [AllowAnonymous]
        public async Task<TokensViewModel> RenewToken([FromBody] RefreshTokenDTO tokenDTO)
        {
            var user = await userManager.Users.SingleAsync(user => user.RefreshToken == tokenDTO.RefreshToken);
            return new TokensViewModel
            {
                AccessToken = tokenService.CreateAccessToken(user),
                RefreshToken = await tokenService.CreateRefreshTokenAsync(user)
            };
        }
    }
}
