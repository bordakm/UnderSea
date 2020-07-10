using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        { // TODO: ha egy játékosnak több országa lesz majd, akk itt az attackeruserid-ből attacking country id-t kéne csinálni
            var game = await db.Game.FirstOrDefaultAsync();
            var unittypes = await db.UnitTypes.ToListAsync();            
            var attackinguser = await db.Users.Include(u=>u.Country).ThenInclude(c=>c.Army).FirstOrDefaultAsync(u => u.Id == attackeruserid);
            var defendingcountry = await db.Countries.FirstOrDefaultAsync(c => c.Id == attack.CountryId);
            var defendinguser = defendingcountry.User;

            var sentunits = new List<Unit>();
            foreach (SendUnitDTO sendunit in attack.AttackingUnits) {
                UnitType type = unittypes.FirstOrDefault(ut => ut.Id == sendunit.Id);
                int ownedcount = attackinguser.Country.Army.Units.FirstOrDefault(u => u.Type == type).Count;
                if (sendunit.SendCount > ownedcount) 
                    throw new Exception("Nem küldhetsz több egységet, mint amennyid van!");
                sentunits.Add(new Unit() {Count = sendunit.SendCount, Type = type});
            }

            game.Attacks.Add(new Attack
            {
                AttackerUser = attackinguser,
                DefenderUser = defendinguser,
                UnitGroup = new UnitGroup 
                {
                    Units = sentunits
                }
            });
            await db.SaveChangesAsync();
        }

        public async Task BuyUnits(int userId, List<UnitPurchaseDTO> purchases)
        {
            var user = await db.Users.Include(user => user.Country)
                .ThenInclude(country => country.Army)
                .FirstAsync(user => user.Id == userId);
            var units = await db.Units.Include(u=>u.Type).ToListAsync();
            int currentSupplyDemand = units.Sum(unit => unit.Count);
            int newSupplyDemand = purchases.Sum(purchase => purchase.Count);
            if (user.Country.Population < currentSupplyDemand + newSupplyDemand)
            {
                throw new Exception("More barracks are needed.");
            }
            int priceTotal = purchases.Sum(purchase => purchase.Count * units.FirstOrDefault(unit => unit.Id == purchase.Id).Type.Price);
            if (priceTotal > user.Country.Pearl)
            {
                throw new Exception("Not enough pearls.");
            }
            units.ForEach(unit => unit.Count += purchases.FirstOrDefault(purchase => purchase.Id == unit.Id).Count);
            await db.SaveChangesAsync();
        }

        public async Task<List<AvailableUnitViewModel>> GetAvailableUnits()
        {
            var user = await db.Users.FirstOrDefaultAsync();
            var units = user.Country.Army.Units;
            return mapper.Map<List<AvailableUnitViewModel>>(units);
        }

        public async Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            var game = await db.Game.FirstOrDefaultAsync();
            var attacks = game.Attacks.ToList();
            var res = new List<OutgoingAttackViewModel>();
            foreach (var item in attacks)
            {
                res.Add(new OutgoingAttackViewModel
                {
                    CountryName = item.AttackerUser.Country.Name,
                    Units = item.UnitGroup
                });
            }

            return res;

        }

        public async Task<List<UnitViewModel>> GetUnits()
        {
            var user = await db.Users.FirstOrDefaultAsync();
            var units = user.Country.Army.Units.ToList();
            return mapper.Map<List<UnitViewModel>>(units);
        }
    }
}
