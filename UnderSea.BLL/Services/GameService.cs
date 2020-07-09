using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL.Services
{
    class GameService : IGameService
    {
        private UnderSeaDbContext db;
        private readonly IMapper mapper;

        public GameService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<List<string>> AttackSearch (SearchDTO search)
        {
            var game = await db.Game.FirstOrDefaultAsync();
            var user = game.Users.FindAll(x => x.UserName.ToUpper().Contains(search.SearchPhrase.ToUpper()))
                                    .Skip(search.ItemPerPage * (search.Page - 1))
                                    .Take(search.ItemPerPage)
                                    .Select(x => x.UserName)
                                    .ToList();

            return user;
        }

        public async Task<MainPageViewModel> GetMainPage()
        {
            var game = await db.Game.FirstOrDefaultAsync();
            var user = game.Users.FirstOrDefault();
            var country = user.Country;

            MainPageViewModel res = new MainPageViewModel()
            {
                CountryName = country.Name,
                StatusBar = new StatusBarViewModel
                {
                    Buildings = country.BuildingGroup,
                    RoundCount = game.Round,
                    ScoreboardPosition = user.Place,
                    Units = country.Army,
                    Resources = new StatusBarViewModel.StatusBarResource()
                    {
                        CoralCount = country.Coral,
                        CoralProductionCount = country.CoralProduction,
                        CoralPictureUrl = game.CoralPictureUrl,
                        PearlCount = country.Pearl,
                        PearlProductionCount = country.PearlProduction,
                        PearlPictureUrl = game.PearlPictureUrl

                    }

                },
                Structures = new StructuresViewModel()
                {
                    FlowManager = (country.BuildingGroup.Buildings.FirstOrDefault(y => y is FlowManager).Count != 0),
                    ReefCastle = (country.BuildingGroup.Buildings.FirstOrDefault(y => y is ReefCastle).Count != 0),
                    Alchemy = (country.Upgrades.FirstOrDefault(y => y is Alchemy).State != UpgradeState.Unresearched),
                    CoralWall = (country.Upgrades.FirstOrDefault(y => y is CoralWall).State != UpgradeState.Unresearched),
                    MudHarvester = (country.Upgrades.FirstOrDefault(y => y is MudHarvester).State != UpgradeState.Unresearched),
                    MudTractor = (country.Upgrades.FirstOrDefault(y => y is MudTractor).State != UpgradeState.Unresearched),
                    SonarCannon = (country.Upgrades.FirstOrDefault(y => y is SonarCannon).State != UpgradeState.Unresearched),
                    UnderwaterMartialArts = (country.Upgrades.FirstOrDefault(y => y is UnderwaterMartialArts).State != UpgradeState.Unresearched),

                }
            };

            return res;
        }

        public async Task NewRound(int rounds)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ScoreboardViewModel>> SearchScoreboard(SearchDTO search)
        {
            var game = await db.Game.FirstOrDefaultAsync();
            var user = game.Users.FindAll(x => x.UserName.ToUpper().Contains(search.SearchPhrase.ToUpper()))
                                    .Skip(search.ItemPerPage * (search.Page - 1))
                                    .Take(search.ItemPerPage)
                                    .ToList();

            return mapper.Map<List<ScoreboardViewModel>>(user);
        }
    }
}
