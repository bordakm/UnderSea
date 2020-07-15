using System.Collections.Generic;
using System.Threading.Tasks;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IUpgradesService
    {
        Task<IEnumerable<UpgradeViewModel>> GetUpgradesAsync(int userid);
        Task<UpgradeViewModel> ResearchByIdAsync(int userid, int upgradeid);
    }
}