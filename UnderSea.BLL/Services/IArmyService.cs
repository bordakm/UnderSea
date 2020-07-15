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
        Task<IEnumerable<UnitViewModel>> GetUnitsAsync(int userId);
        Task<IEnumerable<SimpleUnitViewModel>> BuyUnitsAsync(int userId, List<UnitPurchaseDTO> purchases);
        Task<IEnumerable<AvailableUnitViewModel>> GetAvailableUnitsAsync(int userId);
        Task<IEnumerable<OutgoingAttackViewModel>> GetOutgoingAttacksAsync(int userId);
        Task<IEnumerable<SimpleUnitViewModel>> AttackAsync(int attackeruserid, AttackDTO attack);
    }
}
