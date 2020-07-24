using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.Services;
using UnderSea.BLL.ViewModels;

namespace UnderSea.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UpgradesController : ControllerBase
    {
        private IUpgradesService upgradesService;

        public UpgradesController(IUpgradesService upgradesService)
        {
            this.upgradesService = upgradesService;
        }

        [HttpGet]
        public Task<IEnumerable<UpgradeViewModel>> Get()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return upgradesService.GetUpgradesAsync(userId);
        }

        [HttpPost("research")]
        public Task<UpgradeViewModel> Research([FromBody] IdDTO id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return upgradesService.ResearchByIdAsync(userId, id.Id);
        }
    }
}
