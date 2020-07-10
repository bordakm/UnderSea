using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.Services
{
    class ArmyService: IArmyService
    {
        private readonly UnderSeaDbContext db;
        private readonly IMapper mapper;

        public ArmyService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Attack(int attackeruserid, AttackDTO attack)
        { // TODO: majd ha egy játékosnak több országa lesz majd, akk itt az attackeruserid-ből attacking country id-t kéne csinálni
            var game = await db.Game.FirstAsync();
            var unittypes = await db.UnitTypes.ToListAsync();            
            var attackinguser = await db.Users.Include(u=>u.Country).SingleAsync(u => u.Id == attackeruserid);
            var defendingcountry = await db.Countries.SingleAsync(c => c.Id == attack.CountryId);
            var defendinguser = defendingcountry.User;

            var sentunits = new List<Unit>();

            foreach (SendUnitDTO sendunit in attack.AttackingUnits) {
                UnitType type = unittypes.Single(ut => ut.Id == sendunit.Id);
                int ownedcount = attackinguser.Country.DefendingArmy.Single(u => u.Type == type).Count;
                if (sendunit.SendCount > ownedcount)
                    throw new Exception("Nem küldhetsz több egységet, mint amennyid van!");
                else
                {                    
                    attackinguser.Country.AttackingArmy.Single(u => u.Type == type).Count += sendunit.SendCount;
                    attackinguser.Country.DefendingArmy.Single(u => u.Type == type).Count -= sendunit.SendCount;
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
            var user = await db.Users.Include(user => user.Country)
                .FirstAsync(user => user.Id == userId);
            var units = await db.Units.Include(u=>u.Type).ToListAsync();
            int currentSupplyDemand = units.Sum(unit => unit.Count);
            int newSupplyDemand = purchases.Sum(purchase => purchase.Count);
            if (user.Country.Population < currentSupplyDemand + newSupplyDemand)
            {
                throw new Exception("More barracks are needed.");
            }
            int priceTotal = purchases.Sum(purchase => purchase.Count * units.Single(unit => unit.Id == purchase.Id).Type.Price);
            if (priceTotal > user.Country.Pearl)
            {
                throw new Exception("Not enough pearls.");
            }
            units.ForEach(unit => unit.Count += purchases.Single(purchase => purchase.Id == unit.Id).Count);
            await db.SaveChangesAsync();
        }

        public async Task<List<AvailableUnitViewModel>> GetAvailableUnits(int userId)
        {

            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy.ToList();

            return mapper.Map<List<AvailableUnitViewModel>>(units);
        }

        public async Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks(int userId)
        {
            var attacks = await db.Attacks
                               .Include(attacks => attacks.UnitList)
                               .Where(attacks => attacks.AttackerUser.Id == userId)
                               .ToListAsync();

            //maybe automapper
            var res = new List<OutgoingAttackViewModel>();
            foreach (var item in attacks)
            {
                res.Add(new OutgoingAttackViewModel
                {
                    CountryName = item.AttackerUser.Country.Name,
                    Units = item.UnitList
                });
            }

            return res;

        }

        public async Task<List<UnitViewModel>> GetUnits(int userId)
        {
            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy;

            return mapper.Map<List<UnitViewModel>>(units);
        }
    }
}
