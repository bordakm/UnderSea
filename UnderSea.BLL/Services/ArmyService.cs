using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;

namespace UnderSea.BLL.Services
{
    class ArmyService: IArmyService
    {
        private UnderSeaDbContext db;

        public ArmyService(UnderSeaDbContext db)
        {
            this.db = db;
        }

        public async Task Attacks(AttackDTO attack)
        {
            throw new NotImplementedException();
        }

        public async Task BuyUnits(List<UnitPurchaseDTO> purchases)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AvailableUnitViewModel>> GetAvailableUnits()
        {
            throw new NotImplementedException();
        }

        public async Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UnitViewModel>> GetUnits()
        {
            var units = db.Game.FirstOrDefault().Users.FirstOrDefault().Country.Army.Units.ToList();

        }
    }
}
