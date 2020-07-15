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
        Task<List<BuildingInfoViewModel>> GetBuildingInfosAsync(int userId);
        Task<BuildingInfoViewModel> PurchaseBuildingByIdAsync(int userId, int buildingId);
    }
}
