using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL.Services
{
    class UpgradeService : IUpgradeService
    {
        UnderSeaDbContext db;
        public UpgradeService(UnderSeaDbContext context)
        {
            db = context;
        }
        public async Task<List<UpgradeViewModel>> GetUpgrades(int userid)
        {
            //TODO auth
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades)
                .FirstOrDefaultAsync(u => u.Id == userid);
            int roundsLeft = user.Country.UpgradeTimeLeft;
            return user.Country
            .Upgrades.Select(u =>
                        new UpgradeViewModel
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Description = u.Description,
                            ImageUrl = u.ImageUrl,
                            IsPurchased = u.State == UpgradeState.Researched,
                            RemainingRounds = u.State == UpgradeState.Researched ? 0 : roundsLeft
                        })
            .ToList();
        }

        public async Task<string> ResearchById(int userid, int upgradeid)
        {
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades)
                .ThenInclude(u => u.State)
                .FirstOrDefaultAsync(u => u.Id == userid);

            var upgrade = user.Country.Upgrades.FirstOrDefault(u => u.Id == upgradeid);
            if (upgrade.State == UpgradeState.Unresearched && !user.Country.Upgrades.Any(u => u.State == UpgradeState.InProgress))
            {
                // can upgrade, starting upgrade
                user.Country.UpgradeTimeLeft = 15;
                upgrade.State = UpgradeState.InProgress;
                await db.SaveChangesAsync();
                return ""; // TODO?
            }
            else
            {
                return "Most nem indíthatod el ezt a fejlesztést!";
            }
        }
    }
}
