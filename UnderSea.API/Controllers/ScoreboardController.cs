using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScoreboardController : ControllerBase
    {

        private readonly IGameService gameService;
        private readonly ILogger logger;

        public ScoreboardController(IGameService gameService, ILogger<ScoreboardController> logger)
        {
            this.gameService = gameService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ScoreboardViewModel>> Search([FromQuery] SearchDTO search)
        {
            return await gameService.SearchScoreboardAsync(search);
        }
    }
}
