using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpgradesController : ControllerBase
    {
        private IUpgradesService upgradesService;
        public UpgradesController(IUpgradesService upgradesService)
        {
            this.upgradesService = upgradesService;
        }

        [HttpGet]
        public Task<List<UpgradeViewModel>> Get()
        {
            int userId = 1;
            return upgradesService.GetUpgrades(userId);
        }

        [HttpPost]
        public Task<string> Research([FromBody]int id)
        {
            int userId = 1;
            return upgradesService.ResearchById(userId, id);
        }
    }
}
