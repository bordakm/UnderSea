﻿using AutoMapper;
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
using UnderSea.DAL.Models;
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
            var users = await db.Users
                                .Where(users => users.UserName.ToUpper().Contains(search.SearchPhrase.ToUpper()))
                                .Skip(search.ItemPerPage * (search.Page - 1))
                                .Take(search.ItemPerPage)
                                .Select(users => users.UserName)
                                .ToListAsync();

            return users;
        }

        public async Task<MainPageViewModel> GetMainPage(int userId)
        {
            var game = await db.Game.FirstOrDefaultAsync();
            var user = await db.Users
                                .Include(users => users.Country)
                                .Include(users => users.Country.Army)
                                .Include(users => users.Country.Army.Units)
                                .Include(users => users.Country.BuildingGroup)
                                .Include(users => users.Country.BuildingGroup.Buildings)
                                .Include(users => users.Country.Upgrades)
                                .FirstOrDefaultAsync(user => user.Id == userId);


            MainPageViewModel res = new MainPageViewModel()
            {
                CountryName = user.Country.Name,
                StatusBar = new StatusBarViewModel
                {
                    Buildings = user.Country.BuildingGroup,
                    RoundCount = game.Round,
                    ScoreboardPosition = user.Place,
                    Units = user.Country.Army,
                    Resources = new StatusBarViewModel.StatusBarResource()
                    {
                        CoralCount = user.Country.Coral,
                        CoralProductionCount = user.Country.CoralProduction,
                        CoralPictureUrl = game.CoralPictureUrl,
                        PearlCount = user.Country.Pearl,
                        PearlProductionCount = user.Country.PearlProduction,
                        PearlPictureUrl = game.PearlPictureUrl

                    }

                },
                Structures = new StructuresViewModel()
                {
                    FlowManager = (user.Country.BuildingGroup.Buildings.FirstOrDefault(y => y is FlowManager).Count != 0),
                    ReefCastle = (user.Country.BuildingGroup.Buildings.FirstOrDefault(y => y is ReefCastle).Count != 0),
                    Alchemy = (user.Country.Upgrades.FirstOrDefault(y => y is Alchemy).State != UpgradeState.Unresearched),
                    CoralWall = (user.Country.Upgrades.FirstOrDefault(y => y is CoralWall).State != UpgradeState.Unresearched),
                    MudHarvester = (user.Country.Upgrades.FirstOrDefault(y => y is MudHarvester).State != UpgradeState.Unresearched),
                    MudTractor = (user.Country.Upgrades.FirstOrDefault(y => y is MudTractor).State != UpgradeState.Unresearched),
                    SonarCannon = (user.Country.Upgrades.FirstOrDefault(y => y is SonarCannon).State != UpgradeState.Unresearched),
                    UnderwaterMartialArts = (user.Country.Upgrades.FirstOrDefault(y => y is UnderwaterMartialArts).State != UpgradeState.Unresearched),

                }
                
            };

            return res;
        }

        public async Task NewRound(int rounds)
        {
            AddTaxes();
            AddCoral();
            
            FeedUnits();
            DoUpgrades();
            DoBuildings();
            CalculateAttacks();
            CalculatePosition();
            throw new NotImplementedException();
        }

        public async Task<List<ScoreboardViewModel>> SearchScoreboard(SearchDTO search)
        {
            var users = await db.Users
                               .Where(users => users.UserName.ToUpper().Contains(search.SearchPhrase.ToUpper()))
                               .Skip(search.ItemPerPage * (search.Page - 1))
                               .Take(search.ItemPerPage)
                               .ToListAsync();

            return mapper.Map<List<ScoreboardViewModel>>(users);
        }

        private async void AddTaxes()
        {
            var users = db.Users.Include(user => user.Country);
            await users.ForEachAsync(user => user.Country.AddTaxes());
            await db.SaveChangesAsync();
        }

        private async void AddCoral()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings);
            await users.ForEachAsync(user => user.Country.AddCoral());
            await db.SaveChangesAsync();
        }

        private async void FeedUnits()
        {
            var users = db.Users
                            .Include(user => user.Country)
                            .ThenInclude(country => country.Army)
                            .ThenInclude(army => army.Units)
                            .ThenInclude(units => units.Type);

            await users.ForEachAsync(user => user.Country.FeedUnits());
        }

        private async void DoUpgrades()
        {

        }

        private async void DoBuildings()
        {

        }

        private async void CalculateAttacks()
        {

        }

        private async void CalculatePosition()
        {

        }
    }
}
