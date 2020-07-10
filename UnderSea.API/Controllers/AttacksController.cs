using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public AttacksController(IArmyService armyService)
        {
            this.armyService = armyService;
        }

        [HttpGet]
        public async Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            return await armyService.GetOutgoingAttacks(1); // TODO userid
        }

        [HttpPost]
        public ActionResult<string> Attack([FromBody] AttackDTO attack)
        {
            return NotFound("post error");
        }

        [HttpPost("/search")]
        public ActionResult<List<string>> SearchTargets([FromBody] SearchDTO search)
        {
            return NotFound(new List<string>());
        }

        [HttpGet("/units")]
        public ActionResult<List<AvailableUnitViewModel>> GetAvailableUnits()
        {
            return Ok(new List<AvailableUnitViewModel>());
        }
    }
}
