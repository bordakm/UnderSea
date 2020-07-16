using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            var buildingGroup = new BuildingGroup
            {

            };
            var attackingArmy = new UnitGroup
            {

            };
            var defendingArmy = new UnitGroup
            {

            };
            var upgrade1 = new Upgrade
            {

            };
            var upgrade2 = new Upgrade
            {

            };
            var upgrade3 = new Upgrade
            {

            };
            var upgrades = new List<Upgrade>(new Upgrade[] {
                upgrade1, upgrade2, upgrade3

            });
            var country = new Country
            {
                Name = registerData.CountryName,
                BuildingGroup = buildingGroup,
                AttackingArmy = attackingArmy,
                DefendingArmy = defendingArmy
            };
            var user = new User
            {
                UserName = registerData.UserName,
                GameId = 1
            };
            await db.SaveChangesAsync();
            return user;
        }
    }
}
