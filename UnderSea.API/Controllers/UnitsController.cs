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
    public class UnitsController : ControllerBase
    {
        private IArmyService armyService;
        private readonly ILogger logger;
        public UnitsController(IArmyService armyService, ILogger<UnitsController> logger)
        {
            this.armyService = armyService;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<UnitViewModel>> Get()
        {
            int userId = 1; // TODO
            return await armyService.GetUnitsAsync(userId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<SimpleUnitViewModel>> Buy([FromBody] List<UnitPurchaseDTO> purchases)
        {
            int userId = 1;
            return await armyService.BuyUnitsAsync(userId, purchases);
        }
    }
}
