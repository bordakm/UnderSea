using System.Collections.Generic;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly UnderSeaDbContext db;

        public UserService(UnderSeaDbContext db)
        {
            this.db = db;
        }

        public async Task<User> CreateUserAsync(RegisterDTO registerData)
        {
            var unitTypes = db.UnitTypes;
            var buildingTypes = db.BuildingTypes;
            var upgradeTypes = db.UpgradeTypes;
            var attackingUnits = new List<Unit>();
            var defendingUnits = new List<Unit>();
            var upgrades = new List<Upgrade>();
            var buildings = new List<Building>();
            foreach (var unitType in unitTypes)
            {
                attackingUnits.Add(new Unit
                {
                    Type = unitType
                });
                defendingUnits.Add(new Unit
                {
                    Type = unitType
                });
            }
            foreach (var buildingType in buildingTypes)
            {
                buildings.Add(new Building
                {
                    Type = buildingType,
                    Count = 0
                });
            }
            foreach (var upgradeType in upgradeTypes)
            {
                upgrades.Add(new Upgrade
                {
                    Type = upgradeType,
                    State = UpgradeState.Unresearched
                });
            }
            var buildingGroup = new BuildingGroup
            {
                Buildings = buildings
            };
            var attackingArmy = new UnitGroup
            {
                Units = attackingUnits
            };
            var defendingArmy = new UnitGroup
            {
                Units = defendingUnits
            };
            var user = new User
            {
                UserName = registerData.UserName,
                GameId = 1
            };
            var country = new Country
            {
                Name = registerData.CountryName,
                BuildingGroup = buildingGroup,
                AttackingArmy = attackingArmy,
                DefendingArmy = defendingArmy,
                Upgrades = upgrades,
                User = user
            };
            user.Country = country;
            await db.SaveChangesAsync();
            return user;
        }
    }
}
