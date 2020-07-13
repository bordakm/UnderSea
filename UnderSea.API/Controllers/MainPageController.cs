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

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        private readonly IGameService gameService;

        public MainPageController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public Task<MainPageViewModel> Get()
        {
            int userId = 0;
            return gameService.GetMainPage(userId);
        }

        [HttpPost]
        public Task NewRound([FromBody] int rounds)
        {
            return gameService.NewRound(rounds);
        }
    }
}
