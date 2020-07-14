using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public Task<List<ScoreboardViewModel>> Search([FromQuery] SearchDTO search)
        {
            return gameService.SearchScoreboardAsync(search);
        }
    }
}
