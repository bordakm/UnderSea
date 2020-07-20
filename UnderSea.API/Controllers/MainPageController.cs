using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.ViewModels;
using UnderSea.BLL.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly IUserService userService;
        private readonly ILogger logger;
        
        public MainPageController(IGameService gameService, IUserService userService, ILogger<MainPageController> logger)
        {
            this.gameService = gameService;
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<MainPageViewModel> GetMainPage()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await gameService.GetMainPageAsync(userId);
        }

        [HttpPost("newround")]
        public async Task NewRound([FromQuery] int rounds)
        {
            await gameService.NewRoundAsync(rounds);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ProfileViewModel> GetProfile()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await userService.GetProfileAsync(userId);
        }
    }
}
