using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderSea.API.DTO;

namespace UnderSea.API.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAvailable()
        {
            throw new NotImplementedException();
            List<AvailableUnitDTO> units = ;
            return Ok(units);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Buy([FromBody] List<UnitPurchaseDTO> purchases)
        {
            throw new NotImplementedException();
            return Ok();
        }
    }
}
