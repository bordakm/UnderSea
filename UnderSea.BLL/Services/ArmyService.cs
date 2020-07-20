using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.Services
{
    public class ArmyService : IArmyService
    {
        private readonly UnderSeaDbContext db;
        private readonly IMapper mapper;
        public ArmyService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SimpleUnitViewModel>> AttackAsync(int attackerUserId, AttackDTO attack)
        {
            var game = await db.Game
                .Include(game => game.Attacks)
                .SingleAsync();
            var unitTypes = await db.UnitTypes.ToListAsync();
            var attackingUser = await db.Users
                .Include(u => u.Country)
                .ThenInclude(country => country.DefendingArmy)
                .ThenInclude(defendingArmy => defendingArmy.Units)
                .ThenInclude(unit => unit.Type)
                .Include(u => u.Country)
                .ThenInclude(country => country.AttackingArmy)
                .ThenInclude(attackingArmy => attackingArmy.Units)
                .ThenInclude(unit => unit.Type)
                .SingleAsync(u => u.Id == attackerUserId);
            var defendingCountry = await db.Countries
                .Include(country => country.User)
                .SingleAsync(c => c.UserId == attack.DefenderUserId);
            var defendingUser = defendingCountry.User;

            var sentUnits = new List<Unit>();
            var newUnitGroup = new UnitGroup();
            db.UnitGroups.Add(newUnitGroup);
            await db.SaveChangesAsync();

            foreach (var sendUnit in attack.AttackingUnits)
            {
                UnitType type = unitTypes.Single(ut => ut.Id == sendUnit.Id);
                int ownedCount = attackingUser.Country.DefendingArmy.Units.Single(u => u.Type == type).Count;
                if (sendUnit.SendCount > ownedCount)
                    throw new HttpResponseException { Status = 400, Value = "Nem küldhetsz több egységet, mint amennyid van!" };
                else
                {
                    attackingUser.Country.AttackingArmy.Units.Single(u => u.Type == type).Count += sendUnit.SendCount;
                    attackingUser.Country.DefendingArmy.Units.Single(u => u.Type == type).Count -= sendUnit.SendCount;
                    sentUnits.Add(new Unit() { Count = sendUnit.SendCount, Type = type, UnitGroupId = newUnitGroup.Id });
                }
            }

            game.Attacks.Add(new Attack
            {
                AttackerUserId = attackingUser.Id,
                AttackerUser = attackingUser,
                DefenderUserId = defendingUser.Id,
                DefenderUser = defendingUser,
                GameId = game.Id,
                UnitList = sentUnits
            });
            await db.SaveChangesAsync();
            return mapper.Map<IEnumerable<SimpleUnitViewModel>>(sentUnits);
        }

        public async Task<IEnumerable<SimpleUnitViewModel>> BuyUnitsAsync(int userId, List<UnitPurchaseDTO> purchases)
        {
            //TODO optimalizálás
            var user = await db.Users.Include(user => user.Country)
                                    .ThenInclude(country => country.BuildingGroup)
                                    .ThenInclude(bg => bg.Buildings)
                                    .ThenInclude(buildings => buildings.Type)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.AttackingArmy)
                                    .ThenInclude(aa => aa.Units)
                                    .ThenInclude(units => units.Type)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.DefendingArmy)
                                    .ThenInclude(da => da.Units)
                                    .ThenInclude(units => units.Type)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.Upgrades)
                                    .ThenInclude(upgrades => upgrades.Type)
                                    .FirstAsync(user => user.Id == userId);

            var attackingUnits = user.Country.AttackingArmy.Units;
            var defendingUnits = user.Country.DefendingArmy.Units;
            int currentUnitCount = attackingUnits.Sum(unit => unit.Count) + defendingUnits.Sum(unit => unit.Count);
            int plusUnitCount = purchases.Sum(purchase => purchase.Count);
            if (user.Country.UnitStorage < currentUnitCount + plusUnitCount)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs elég helyed a barrakkodban!" };
            }
            int priceTotal = purchases.Sum(purchase => purchase.Count * defendingUnits.Single(unit => unit.Type.Id == purchase.TypeId).Type.Price);
            if (priceTotal > user.Country.Pearl)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs eléd gyöngyöd!" };
            }
            user.Country.Pearl -= priceTotal;
            purchases.ForEach(pur => defendingUnits.Single(units => units.Type.Id == pur.TypeId).Count += pur.Count);
            await db.SaveChangesAsync();
            return mapper.Map<List<UnitPurchaseDTO>, IEnumerable<SimpleUnitViewModel>>(purchases);
        }

        public async Task<IEnumerable<AvailableUnitViewModel>> GetAvailableUnitsAsync(int userId)
        {
            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .ThenInclude(army => army.Units)
                               .ThenInclude(unit => unit.Type)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy.Units;
            return mapper.Map<IEnumerable<Unit>, IEnumerable<AvailableUnitViewModel>>(units);
        }

        public async Task<IEnumerable<OutgoingAttackViewModel>> GetOutgoingAttacksAsync(int userId)
        {
            var attacks = await db.Attacks
                               .Include(attack => attack.UnitList)
                               .ThenInclude(u => u.Type)
                               .Include(attack => attack.AttackerUser)
                               .ThenInclude(attacker => attacker.Country)
                               .Include(attack => attack.DefenderUser)
                               .Where(attacks => attacks.AttackerUser.Id == userId)
                               .ToListAsync();

            var response = new List<OutgoingAttackViewModel>();
            foreach (var attack in attacks)
            {
                var units = mapper.Map<List<SimpleUnitWithNameViewModel>>(attack.UnitList);
                response.Add(new OutgoingAttackViewModel
                {
                    CountryName = attack.AttackerUser.Country.Name,
                    Units = units
                });
            }
            return response;
        }

        public async Task<IEnumerable<UnitViewModel>> GetUnitsAsync(int userId)
        {
            var country = await db.Countries.SingleAsync(c => c.UserId == userId);
            var units = db.Units.Where(u => u.UnitGroupId == country.DefendingArmyId).Include(u => u.Type);
            return mapper.Map<IEnumerable<Unit>, IEnumerable<UnitViewModel>>(units);
        }
    }
}
