using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
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
        private readonly ILogger logger;

        public UpgradesController(IUpgradesService upgradesService, ILogger<UpgradesController> logger)
        {
            this.upgradesService = upgradesService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<UpgradeViewModel>> Get()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await upgradesService.GetUpgradesAsync(userId);
        }

        [HttpPost("research")]
        public async Task<UpgradeViewModel> Research([FromBody] int id)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await upgradesService.ResearchByIdAsync(userId, id);
        }
    }
}
