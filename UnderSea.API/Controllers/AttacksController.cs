using System.Collections.Generic;
using System.Security.Claims;
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
    public class AttacksController : ControllerBase
    {
        private IArmyService armyService;
        private IGameService gameService;

        public AttacksController(IArmyService armyService, IGameService gameService)
        {
            this.armyService = armyService;
            this.gameService = gameService;
        }

        [HttpGet("getoutgoing")]
        public Task<IEnumerable<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return armyService.GetOutgoingAttacksAsync(userId);
        }

        [HttpPost("send")]
        public Task<IEnumerable<SimpleUnitViewModel>> Attack([FromBody] AttackDTO attack)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return armyService.AttackAsync(userId, attack);
        }

        [HttpGet("searchtargets")]
        public Task<IEnumerable<ScoreboardViewModel>> SearchTargets([FromQuery] SearchDTO search)
        {
            // ha egy usernek több countryja lesz, itt majd ScoreboardViewModel helyett olyat kell odaadni ami country nevet ad, nem usert
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return gameService.SearchTargetsAsync(search, userId);
        }

        [HttpGet("getunits")]
        public Task<IEnumerable<AvailableUnitViewModel>> GetAvailableUnits()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return armyService.GetAvailableUnitsAsync(userId);
        }
    }
}
