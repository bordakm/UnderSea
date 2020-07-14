using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger logger;

        public ArmyService(UnderSeaDbContext db, ILogger<ArmyService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task Attack(int attackeruserid, AttackDTO attack)
        { // TODO: majd ha egy játékosnak több országa lesz majd, akk itt az attackeruserid-ből attacking country id-t kéne csinálni
            var game = await db.Game.SingleAsync();
            var unittypes = await db.UnitTypes.ToListAsync();            
            var attackinguser = await db.Users.Include(u=>u.Country).SingleAsync(u => u.Id == attackeruserid);
            var defendingcountry = await db.Countries.SingleAsync(c => c.Id == attack.DefenderUserId);
            var defendinguser = defendingcountry.User;

            var sentunits = new List<Unit>();

            foreach (SendUnitDTO sendunit in attack.AttackingUnits) {
                UnitType type = unittypes.Single(ut => ut.Id == sendunit.Id);
                int ownedcount = attackinguser.Country.DefendingArmy.Units.Single(u => u.Type == type).Count;
                if (sendunit.SendCount > ownedcount)
                    throw new Exception("Nem küldhetsz több egységet, mint amennyid van!");
                else
                {                    
                    attackinguser.Country.AttackingArmy.Units.Single(u => u.Type == type).Count += sendunit.SendCount;
                    attackinguser.Country.DefendingArmy.Units.Single(u => u.Type == type).Count -= sendunit.SendCount;
                    sentunits.Add(new Unit() {Count = sendunit.SendCount, Type = type});
                }
            }

            game.Attacks.Add(new Attack
            {
                AttackerUser = attackinguser,
                DefenderUser = defendinguser,
                UnitList = sentunits
            });
            await db.SaveChangesAsync();
        }

        public async Task BuyUnits(int userId, List<UnitPurchaseDTO> purchases)
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
                throw new Exception("More barracks are needed.");
            }
            int priceTotal = purchases.Sum(purchase => purchase.Count * defendingUnits.Single(unit => unit.Type.Id  == purchase.TypeId).Type.Price);
            if (priceTotal > user.Country.Pearl)
            {
                throw new Exception("Not enough pearls.");
            }
            user.Country.Pearl -= priceTotal;
            purchases.ForEach(pur => defendingUnits.Single(units => units.Type.Id == pur.TypeId).Count += pur.Count);
            await db.SaveChangesAsync();
        }

        public async Task<List<AvailableUnitViewModel>> GetAvailableUnits(int userId)
        {

            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .ThenInclude(army => army.Units)
                               .ThenInclude(unit => unit.Type)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy.Units;

            List<AvailableUnitViewModel> res = new List<AvailableUnitViewModel>();

            foreach (var unit in units)
            {
                var localres = new AvailableUnitViewModel
                {
                    Name = unit.Type.Name,
                    ImageUrl = unit.Type.ImageUrl,
                    AvailableCount = unit.Count,
                    Id = unit.Type.Id
                };
                res.Add(localres);
            }

            return res;
        }

        public async Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks(int userId)
        {
            var attacks = await db.Attacks
                               .Include(attack => attack.UnitList)
                               .Include(attack => attack.AttackerUser)
                               .ThenInclude(attacker => attacker.Country)
                               .Include(attack => attack.DefenderUser)
                               .Where(attacks => attacks.AttackerUser.Id == userId)
                               .ToListAsync();

            var res = new List<OutgoingAttackViewModel>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Unit, SimpleUnitViewModel>());
            var mapper = new Mapper(config);
            foreach (var attack in attacks)
            {
                var units = new List<SimpleUnitViewModel>();
                foreach (var unit in attack.UnitList)
                {
                    units.Add(mapper.Map<SimpleUnitViewModel>(unit));
                }
                res.Add(new OutgoingAttackViewModel
                {
                    CountryName = attack.AttackerUser.Country.Name,
                    Units = units
                });
            }

            return res;

        }

        public async Task<List<UnitViewModel>> GetUnits(int userId)
        {
            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .ThenInclude(def=>def.Units)
                               .ThenInclude(unit => unit.Type)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy.Units;

            List<UnitViewModel> res = new List<UnitViewModel>();

            foreach (var unit in units)
            {
                var localres = new UnitViewModel
                {
                    AttackScore = unit.Type.AttackScore,
                    CoralCostPerTurn = unit.Type.CoralCostPerTurn,
                    Count = unit.Count,
                    DefenseScore = unit.Type.DefenseScore,
                    ImageUrl = unit.Type.ImageUrl,
                    Name = unit.Type.Name,
                    PearlCostPerTurn = unit.Type.PearlCostPerTurn,
                    Price = unit.Type.Price,
                    Id = unit.Type.Id
                };
                res.Add(localres);
            }

            return res;
        }
    }
}
