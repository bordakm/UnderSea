using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.ViewModels;
using UnderSea.BLL.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using UnderSea.BLL.DTO;

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
        public Task<MainPageViewModel> GetMainPage()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return gameService.GetMainPageAsync(userId);
        }

        [HttpPost("newround")]
        public Task NewRound([FromBody] RoundsDTO rounds)
        {
            return gameService.NewRoundAsync(rounds.Number);
        }

        [HttpGet("profile")]
        [Authorize]
        public Task<ProfileViewModel> GetProfile()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return userService.GetProfileAsync(userId);
        }
    }
}
