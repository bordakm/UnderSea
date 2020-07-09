using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttacksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            return NotFound(new List<OutgoingAttackViewModel>());
        }

        [HttpPost]
        public ActionResult<string> Attack([FromBody] AttackDTO attack)
        {
            return NotFound("post error");
        }

        [HttpPost]
        [Route("/search")]
        public ActionResult<List<string>> SearchTargets([FromBody] SearchDTO search)
        {
            return NotFound(new List<string>());
        }

        [HttpGet]
        [Route("/units")]
        public ActionResult<List<AvailableUnitViewModel>> GetAvailableUnits()
        {
            return Ok(new List<AvailableUnitViewModel>());
        }
    }
}
