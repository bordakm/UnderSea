﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
                                .Include(users => users.Country.DefendingArmy)
                                .Include(users => users.Country.BuildingGroup)
                                .Include(users => users.Country.BuildingGroup.Buildings)
                                .Include(users => users.Country.Upgrades)
                                .ThenInclude(u=>u.Type)
                                .FirstOrDefaultAsync(user => user.Id == userId);


            MainPageViewModel res = new MainPageViewModel()
            {
                CountryName = user.Country.Name,
                StatusBar = new StatusBarViewModel
                {
                    Buildings = user.Country.BuildingGroup,
                    RoundCount = game.Round,
                    ScoreboardPosition = user.Place,
                    Units = user.Country.DefendingArmy,
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

                    Alchemy = (user.Country.Upgrades.FirstOrDefault(y => y.Type is Alchemy).State != UpgradeState.Unresearched),
                    CoralWall = (user.Country.Upgrades.FirstOrDefault(y => y.Type is CoralWall).State != UpgradeState.Unresearched),
                    MudHarvester = (user.Country.Upgrades.FirstOrDefault(y => y.Type is MudHarvester).State != UpgradeState.Unresearched),
                    MudTractor = (user.Country.Upgrades.FirstOrDefault(y => y.Type is MudTractor).State != UpgradeState.Unresearched),
                    SonarCannon = (user.Country.Upgrades.FirstOrDefault(y => y.Type is SonarCannon).State != UpgradeState.Unresearched),
                    UnderwaterMartialArts = (user.Country.Upgrades.FirstOrDefault(y => y.Type is UnderwaterMartialArts).State != UpgradeState.Unresearched),
                }                
            };
            return res;
        }

        public async Task NewRound(int rounds = 1)
        {
            for (int i = 0; i < rounds; ++i)
            {
                AddTaxes();
                AddCoral();
                PayUnits();
                FeedUnits();
                DoUpgrades();
                Build();
                CalculateAttacks();
                CalculateRankings();
            }
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
                            .ThenInclude(country => country.AttackingArmy)
                            .ThenInclude(aa => aa.Type)
                            .Include(user => user.Country.DefendingArmy)
                            .ThenInclude(da => da.Type);

            await users.ForEachAsync(user => user.Country.FeedUnits());
            await db.SaveChangesAsync();
        }

        private async void DoUpgrades()
        {
            var users = db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades);
            await db.Countries.ForEachAsync(country => country.DoUpgrades());
            await db.SaveChangesAsync();
        }

        private async void CalculateAttacks()
        {
            var game = db.Game
                            .Include(game => game.Attacks)
                            .Include(game => game.Users)
                            .ThenInclude(users => users.Country)
                            .ThenInclude(country => country.AttackingArmy)
                            .ThenInclude(units => units.Type)
                            .Include(game => game.Users)
                            .ThenInclude(u => u.Country)
                            .ThenInclude(c => c.DefendingArmy)
                            .ThenInclude(da => da.Type);
            await game.ForEachAsync(g => g.CalculateAttacks());
            await db.SaveChangesAsync();
        }

        private async void PayUnits()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.AttackingArmy)
                .Include(user => user.Country)
                .ThenInclude(country => country.DefendingArmy);
            await users.ForEachAsync(user => user.Country.PayUnits());
            await db.SaveChangesAsync();
        }

        private async void Build()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings);
            await users.ForEachAsync(user => user.Country.Build());
            await db.SaveChangesAsync();
        }

        private async void CalculateRankings()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings)
                .ThenInclude(b=>b.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.Upgrades);
            await users.ForEachAsync(user => user.Score = user.Country.CalculateScore());
            users.OrderByDescending(user => user.Score);
            int rank = 1;
            await users.ForEachAsync(user => user.Place = rank++);
            await db.SaveChangesAsync();
        }
    }
}
