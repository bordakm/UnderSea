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
        private UnderSeaDbContext db;
        private readonly IMapper mapper;

        public ArmyService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task Attack(int attackeruserid, AttackDTO attack)
        { // TODO: ha egy játékosnak több országa lesz majd, akk itt az attackeruserid-ből attacking country id-t kéne csinálni
            var game = await db.Game.FirstOrDefaultAsync();
            
            var attackinguser = await db.Users.FirstOrDefaultAsync(u => u.Id == attackeruserid);
            var defendingcountry = await db.Countries.FirstOrDefaultAsync(c => c.Id == attack.CountryId);
            var defendinguser = defendingcountry.User;

            game.Attacks.Add(new Attack
            {
                AttackerUser = attackinguser,
                DefenderUser = defendinguser,
                UnitGroup = new UnitGroup 
                {
                    Units = new List<Unit>{ 
                        new StormSeal(){ Count = attack.AttackingUnits .....}, // TODO minden típusnak beállítani, hogy hányat küldött..
                        new CombatSeaHorse(),
                        new LaserShark()}
                }
            }) ;
            await db.SaveChangesAsync();
        }

        public async Task BuyUnits(List<UnitPurchaseDTO> purchases)
        {
            //same as the upper one
            throw new NotImplementedException();
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
