using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models;

namespace UnderSea.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IUserService userService;
        private readonly IGameService gameService;
        private readonly ILogger logger;

        public AuthService(SignInManager<User> signInManager, UserManager<User> userManager, ITokenService tokenService,
            IUserService userService, IGameService gameService, ILogger<AuthService> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.userService = userService;
            this.gameService = gameService;
            this.logger = logger;
        }

        public async Task<TokensViewModel> Login(LoginDTO loginData)
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

        public async Task Logout(ClaimsPrincipal user)
        {
            var myUser = await userManager.GetUserAsync(user);
            await signInManager.SignOutAsync();
            await tokenService.RemoveRefreshTokenAsync(myUser);
        }

        public async Task<TokensViewModel> Register(RegisterDTO registerData)
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

        public async Task<TokensViewModel> RenewToken(RefreshTokenDTO tokenDTO)
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
