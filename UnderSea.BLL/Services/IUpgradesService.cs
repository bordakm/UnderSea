using System.Collections.Generic;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IUpgradesService
    {
        Task<List<UpgradeViewModel>> GetUpgrades();
        Task<string> ResearchById(int id);
    }
}