using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;

namespace UnderSea.BLL.Services
{
    class UpgradesService : IUpgradesService
    {
        UnderSeaDbContext db;
        public UpgradesService(UnderSeaDbContext context)
        {
            db = context;
        }
        public async Task<List<UpgradeViewModel>> GetUpgrades()
        {
            var user = await db.Users.FirstOrDefaultAsync();
            int roundsLeft = user.Country.UpgradeTimeLeft;

            return user.Country
            .Upgrades.Select(u =>
                        new UpgradeViewModel{ 
                            Id = u.Id,
                            Name = u.Name,
                            Description = u.Description,
                            ImageUrl = u.ImageUrl,
                            IsPurchased = u.State == DAL.Models.Upgrades.UpgradeState.Researched,
                            RemainingRounds = u.State == DAL.Models.Upgrades.UpgradeState.Researched ? 0 : roundsLeft })
            .ToList();

        }

        public async Task<string> ResearchById(int id)
        {            
            return "Upgrade started"; // TODO 
        }
    }
}
