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
        public Task<MainPageViewModel> GetMainPageAsync(int userId);
        public Task NewRoundAsync(int rounds);
        public Task<List<ScoreboardViewModel>> SearchScoreboardAsync(SearchDTO search);
    }
}
