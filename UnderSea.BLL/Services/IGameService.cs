﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;

namespace UnderSea.BLL.Services
{
    interface IGameService
    {
        public Task<List<string>> AttackSearch(SearchDTO search);
        public Task<MainPageViewModel> GetMainPage(int userId);
        public void NewRound(int rounds);
        public Task<List<ScoreboardViewModel>> SearchScoreboard(SearchDTO search);
    }
}
