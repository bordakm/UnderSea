using System.Collections.Generic;
using System.Linq;
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
    public class BuildingsController : ControllerBase
    {
        private readonly IBuildingsService buildingsService;

        public BuildingsController(IBuildingsService buildingsService)
        {
            this.buildingsService = buildingsService;
        }

        [HttpGet]
        public async Task<IEnumerable<BuildingInfoViewModel>> GetBuildingInfos()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await buildingsService.GetBuildingInfosAsync(userId);
        }

        [HttpPost("purchase")]
        public async Task<BuildingInfoViewModel> PurchaseBuilding([FromBody] IdDTO buildingId)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await buildingsService.PurchaseBuildingByIdAsync(userId, buildingId.Id);
            var buildings = await GetBuildingInfos();
            return buildings.Single(b => b.Id == buildingId.Id);
        }
    }
}
