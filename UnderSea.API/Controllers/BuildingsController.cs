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
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingsService buildingsService;
        private readonly ILogger logger;

        public BuildingsController(IBuildingsService buildingsService, ILogger<BuildingsController> logger)
        {
            this.buildingsService = buildingsService;
            this.logger = logger;
        }

        [HttpGet]
        public Task<List<BuildingInfoViewModel>> GetBuildingInfos()
        {
            int userId = 1;
            return buildingsService.GetBuildingInfos(userId);
        }

        [HttpPost]
        public Task PurchaseBuilding([FromBody] int buildingId)
        {
            int userId = 0;
            return buildingsService.PurchaseBuildingById(userId, buildingId);
        }
    }
}
