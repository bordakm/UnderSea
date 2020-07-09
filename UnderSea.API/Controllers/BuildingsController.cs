using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public BuildingsController(IBuildingsService buildingsService)
        {
            this.buildingsService = buildingsService;
        }

        [HttpGet]
        public Task<List<BuildingInfoViewModel>> GetBuildingInfos()
        {
            return buildingsService.GetBuildingInfos();
        }

        [HttpPost]
        public Task PurchaseBuilding([FromBody] int buildingId)
        {
            int userId = 0;
            return buildingsService.PurchaseBuildingById(userId, buildingId);
        }
    }
}
