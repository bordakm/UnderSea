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
        public Task<List<UnitViewModel>> Get()
        {
            int userId = 1; // TODO
            return armyService.GetUnits(userId);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<List<SimpleUnitViewModel>> Buy([FromBody]List<UnitPurchaseDTO> purchases)
        {
            int userId = 1;
            return armyService.BuyUnits(userId, purchases);
        }
    }
}
