using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IArmyService
    {
        public Task<List<UnitViewModel>> GetUnitsAsync(int userId);
        public Task<List<SimpleUnitViewModel>> BuyUnitsAsync(int userId, List<UnitPurchaseDTO> purchases);
        public Task<List<AvailableUnitViewModel>> GetAvailableUnitsAsync(int userId);
        public Task<List<OutgoingAttackViewModel>> GetOutgoingAttacksAsync(int userId);
        public Task<List<SimpleUnitViewModel>> AttackAsync(int attackeruserid, AttackDTO attack);
    }
}
