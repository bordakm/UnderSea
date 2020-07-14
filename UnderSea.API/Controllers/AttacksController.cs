using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttacksController : ControllerBase
    {
        private IArmyService armyService;
        private IGameService gameService;
        private readonly ILogger logger;

        public AttacksController(IArmyService armyService, IGameService gameService, ILogger<AttacksController> logger)
        {
            this.armyService = armyService;
            this.gameService = gameService;
            this.logger = logger;
        }

        [HttpGet("getoutgoing")]
        public Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            int userId = 1;
            return armyService.GetOutgoingAttacks(userId); // TODO userid
        }

        [HttpPost("send")]
        public Task<string> Attack([FromBody] AttackDTO attack)
        {
            int userId = 1;
            armyService.Attack(userId, attack);
            return Task.Run( () => { return "TODO"; }); // TODO ??
        }

        [HttpGet("searchtargets")]
        public Task<List<ScoreboardViewModel>> SearchTargets([FromQuery] SearchDTO search)
        { 
            // ha egy usernek több countryja lesz, itt majd ScoreboardViewModel helyett olyat kell odaadni ami country nevet ad, nem usert
            return gameService.SearchScoreboard(search);
        }

        [HttpGet("getunits")]
        public Task<List<AvailableUnitViewModel>> GetAvailableUnits()
        {
            int userId = 1; // TODO userid
            return armyService.GetAvailableUnits(userId);
        }
    }
}
