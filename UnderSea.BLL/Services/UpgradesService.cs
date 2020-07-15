using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL.Services
{
    public class UpgradesService : IUpgradesService
    {
        UnderSeaDbContext db;
        private readonly ILogger logger;
        public UpgradesService(UnderSeaDbContext context, ILogger<UpgradesService> logger)
        {
            db = context;
            this.logger = logger;
        }
        public async Task<IEnumerable<UpgradeViewModel>> GetUpgradesAsync(int userid)
        {
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades)
                .ThenInclude(u => u.Type)
                .SingleAsync(u => u.Id == userid);
            int roundsLeft = user.Country.UpgradeTimeLeft;
            return user.Country
            .Upgrades.Select(u =>
                        new UpgradeViewModel
                        {
                            Id = u.Type.Id,
                            Name = u.Type.Name,
                            Description = u.Type.Description,
                            ImageUrl = u.Type.ImageUrl,
                            IsPurchased = u.State == UpgradeState.Researched,
                            RemainingRounds = u.State == UpgradeState.Researched ? 0 : roundsLeft
                        })
            .ToList();
        }

        public async Task<UpgradeViewModel> ResearchByIdAsync(int userId, int upgradeTypeId)
        {
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades)
                .ThenInclude(u => u.Type)
                .SingleAsync(u => u.Id == userId);

            var upgrade = user.Country.Upgrades.Single(u => u.Type.Id == upgradeTypeId);
            if (upgrade.State == UpgradeState.Unresearched && !user.Country.Upgrades.Any(u => u.State == UpgradeState.InProgress))
            {
                // can upgrade, starting upgrade
                user.Country.UpgradeTimeLeft = 15;
                upgrade.State = UpgradeState.InProgress;
                await db.SaveChangesAsync();
                var upgrades = await GetUpgradesAsync(userId);
                return upgrades.Single(u => u.Id == upgradeTypeId);
            }
            else
            {
                throw new Exception("Most nem indíthatod el ezt a fejlesztést!");
            }
        }
    }
}
