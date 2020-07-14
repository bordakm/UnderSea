using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Models.Buildings;

namespace UnderSea.BLL.Services
{
    public interface IBuildingsService
    {
        public Task<List<BuildingInfoViewModel>> GetBuildingInfosAsync(int userId);

        public Task<BuildingInfoViewModel> PurchaseBuildingByIdAsync(int userId, int buildingId);        
    }
}
