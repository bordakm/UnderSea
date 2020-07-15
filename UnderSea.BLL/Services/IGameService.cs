using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    public interface IGameService
    {
        Task<MainPageViewModel> GetMainPageAsync(int userId);
        Task NewRoundAsync(int rounds);
        Task<IEnumerable<ScoreboardViewModel>> SearchScoreboardAsync(SearchDTO search);
    }
}
