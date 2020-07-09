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

        public async Task Attack(AttackDTO attack)
        {
            //result ??? logika ellenőrzése? idk
            throw new NotImplementedException();
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
