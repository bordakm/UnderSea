using AutoMapper;
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
        private readonly IMapper mapper;
        public UpgradesService(UnderSeaDbContext context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UpgradeViewModel>> GetUpgradesAsync(int userid)
        {
            var user = await db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades)
                .ThenInclude(u => u.Type)
                .SingleAsync(u => u.Id == userid);
            int roundsLeft = user.Country.UpgradeTimeLeft;           
            return mapper.Map<IEnumerable<Upgrade>, IEnumerable<UpgradeViewModel>>(user.Country.Upgrades);
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
                throw new HttpResponseException { Status = 400, Value = "Most nem indíthatod el ezt a fejlesztést!" };
            }
        }
    }
}
