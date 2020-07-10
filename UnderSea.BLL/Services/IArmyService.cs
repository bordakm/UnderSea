using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    interface IArmyService
    {
        public Task<List<UnitViewModel>> GetUnits(int userId);
        public Task BuyUnits(int userId, List<UnitPurchaseDTO> purchases);
        public Task<List<AvailableUnitViewModel>> GetAvailableUnits(int userId);
        public Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks(int userId);
        public Task Attack(int attackeruserid, AttackDTO attack);
    }
}
