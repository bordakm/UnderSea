using System.Collections.Generic;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IUpgradeService
    {
        Task<List<UpgradeViewModel>> GetUpgrades();
        Task<string> ResearchById(int id);
    }
}