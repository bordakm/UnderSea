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
        public Task<List<UnitViewModel>> GetUnits();
        public Task BuyUnits(List<UnitPurchaseDTO> purchases);
        public Task<List<AvailableUnitViewModel>> GetAvailableUnits();
        public Task<List<OutgoingAttackViewModel>> GetOutgoingAttacks();
        public Task Attack(AttackDTO attack);

    }
}
