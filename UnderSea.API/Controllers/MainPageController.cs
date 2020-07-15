using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.BLL.Services;
using UnderSea.DAL.Models;
using Microsoft.Extensions.Logging;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly IGameService gameService;
        private readonly ILogger logger;

        public MainPageController(IGameService gameService, ILogger<MainPageController> logger)
        {
            this.gameService = gameService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<MainPageViewModel> GetMainPage()
        {
            int userId = 1;
            return await gameService.GetMainPageAsync(userId);
        }

        [HttpPost("newround")]
        public async void NewRound([FromQuery] int rounds)
        {
            await gameService.NewRoundAsync(rounds);
        }
    }
}
