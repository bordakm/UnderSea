using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.API.DTO;

namespace UnderSea.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<List<UnitDTO>> GetUnitInfo()
        {
            List<UnitDTO> units = new List<UnitDTO>();
            return Task.FromResult(units);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task Buy([FromBody] List<UnitPurchaseDTO> purchases)
        {
            return Task.FromResult(new Object());
        }
    }
}
