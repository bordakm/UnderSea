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
        Task<List<UnitViewModel>> GetUnitsAsync(int userId);
        Task<List<SimpleUnitViewModel>> BuyUnitsAsync(int userId, List<UnitPurchaseDTO> purchases);
        Task<List<AvailableUnitViewModel>> GetAvailableUnitsAsync(int userId);
        Task<List<OutgoingAttackViewModel>> GetOutgoingAttacksAsync(int userId);
        Task<List<SimpleUnitViewModel>> AttackAsync(int attackeruserid, AttackDTO attack);
    }
}
