using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.BLL.Services
{
    public class GameService : IGameService
    {
        private UnderSeaDbContext db;
        private readonly ILogger logger;
        public GameService(UnderSeaDbContext db, ILogger<GameService> logger)
        {
            this.db = db;
            this.logger = logger;
        }

        public async Task<MainPageViewModel> GetMainPageAsync(int userId)
        {
            var game = await db.Game.SingleAsync();
            var user = await db.Users
                                .Include(users => users.Country)
                                .ThenInclude(country => country.DefendingArmy)
                                .ThenInclude(da => da.Units)
                                .ThenInclude(units => units.Type)
                                .Include(users => users.Country.BuildingGroup)
                                .ThenInclude(bGroup => bGroup.Buildings)
                                .ThenInclude(buildings => buildings.Type)
                                .Include(users => users.Country.Upgrades)
                                .ThenInclude(u=>u.Type)
                                .SingleAsync(user => user.Id == userId);


            MainPageViewModel res = new MainPageViewModel()
            {
                CountryName = user.Country.Name,
                StatusBar = new StatusBarViewModel
                {
                    Buildings = user.Country.BuildingGroup,
                    RoundCount = game.Round,
                    ScoreboardPosition = user.Place,
                    Units = user.Country.DefendingArmy.Units,
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
                    FlowManager = (user.Country.BuildingGroup.Buildings.Single(y => y.Type is FlowManager).Count != 0),
                    ReefCastle = (user.Country.BuildingGroup.Buildings.Single(y => y.Type is ReefCastle).Count != 0),

                    Alchemy = (user.Country.Upgrades.Single(y => y.Type is Alchemy).State != UpgradeState.Unresearched),
                    CoralWall = (user.Country.Upgrades.Single(y => y.Type is CoralWall).State != UpgradeState.Unresearched),
                    MudHarvester = (user.Country.Upgrades.Single(y => y.Type is MudHarvester).State != UpgradeState.Unresearched),
                    MudTractor = (user.Country.Upgrades.Single(y => y.Type is MudTractor).State != UpgradeState.Unresearched),
                    SonarCannon = (user.Country.Upgrades.Single(y => y.Type is SonarCannon).State != UpgradeState.Unresearched),
                    UnderwaterMartialArts = (user.Country.Upgrades.Single(y => y.Type is UnderwaterMartialArts).State != UpgradeState.Unresearched),
                }                
            };
            return res;
        }

        public async Task NewRoundAsync(int rounds = 1)
        {
            //for (int i = 0; i < rounds; ++i)
            //{
            //    await AddTaxes();
            //    await AddCoral();
            //    await PayUnits();
            //    await FeedUnits();
            //    await DoUpgrades();
            //    await Build();
            //    await CalculateAttacks();
            //    await CalculateRankings();
            //}

           await Task.Run(() => { return "TODO"; });
        }

        public async Task<List<ScoreboardViewModel>> SearchScoreboardAsync(SearchDTO search)
        {
            int perpage = search.ItemPerPage ?? 10;
            int pagenum = search.Page ?? 1;
            var users = await db.Users
                               .Where(users => users.UserName.ToUpper().Contains(search.SearchPhrase.ToUpper()))
                               .Skip(perpage * (pagenum - 1))
                               .Take(perpage)
                               .ToListAsync();

            List<ScoreboardViewModel> res = new List<ScoreboardViewModel>();

            foreach (var user in users)
            {
                var localres = new ScoreboardViewModel
                {
                    Id = user.Id,
                    Place = user.Place,
                    Score = user.Score,
                    UserName = user.UserName
                };

                res.Add(localres);
            }

            return res;
        }

        private async Task AddTaxes()
        {
            var users = db.Users
                .Include(user => user.Country)
                .ThenInclude(c => c.BuildingGroup)
                .ThenInclude(bg => bg.Buildings)
                .ThenInclude(b => b.Type);
            foreach (var user in users)
            {
                user.Country.AddTaxes();
            }
            await db.SaveChangesAsync();
        }

        private async Task AddCoral()
        {
            var users =
                db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings);

            foreach (var user in users)
            {
                user.Country.AddCoral();
            }
            await db.SaveChangesAsync();
        }

        private async Task DoUpgrades()
        {
            var users = db.Users
                .Include(u => u.Country)
                .ThenInclude(c => c.Upgrades);
            var countries = db.Countries.Include(c => c.Upgrades);
            foreach (var country in countries)
            {
                country.DoUpgrades();
            }
            await db.SaveChangesAsync();
        }

        private async Task CalculateAttacks()
        {
            var game = db.Game
                            .Include(game => game.Attacks)
                            .Include(game => game.Users)
                            .ThenInclude(users => users.Country)
                            .ThenInclude(country => country.AttackingArmy)
                            .ThenInclude(army => army.Units)
                            .ThenInclude(units => units.Type)
                            .Include(game => game.Users)
                            .ThenInclude(u => u.Country)
                            .ThenInclude(c => c.DefendingArmy)
                            .ThenInclude(da => da.Units)
                            .ThenInclude(units => units.Type)
                            .Single();
            game.CalculateAttacks();
            await db.SaveChangesAsync();
        }

        private async Task FeedUnits()
        {
            var game = db.Game.Single();
            var users = db.Users
                            .Include(user => user.Country)
                            .ThenInclude(country => country.AttackingArmy)
                            .ThenInclude(aa => aa.Units)
                            .ThenInclude(units => units.Type)
                            .Include(user => user.Country.DefendingArmy)
                            .ThenInclude(da => da.Units)
                            .ThenInclude(units => units.Type);
            foreach (var user in users)
            {
                var removeUnits = user.Country.FeedUnits();
                //RemoveUnitsFromAttackingList(removeUnits, user);
                var userAttacks = game.Attacks.Where(attack => attack.AttackerUser.Id == user.Id);
                bool stop = false;
                while (!stop)
                {
                    foreach (Attack attack in userAttacks)
                    {
                        foreach (int unitId in removeUnits.Keys)
                        {
                            var unitToRemove = attack.UnitList.Find(unit => unit.Id == unitId);
                            if (unitToRemove.Count > 0 && removeUnits[unitId] > 0)
                            {
                                removeUnits[unitId]--;
                                unitToRemove.Count--;
                            }
                        }
                        stop = removeUnits.Values.All(count => count == 0);
                        if (stop)
                        {
                            break;
                        }
                    }
                }
            }
            await db.SaveChangesAsync();
        }

        private async Task PayUnits()
        {
            var game = db.Game
                .Include(game => game.Attacks)
                .ThenInclude(attacks => attacks.AttackerUser)
                .Include(game => game.Attacks)
                .ThenInclude(attacks => attacks.UnitList)
                .ThenInclude(ul => ul.Type)
                .Include(game => game.Users)
                .ThenInclude(user => user.Country)
                .ThenInclude(country => country.AttackingArmy)
                .ThenInclude(aa => aa.Units)
                .ThenInclude(units => units.Type)
                .Include(game => game.Users)
                .ThenInclude(user => user.Country)
                .ThenInclude(country => country.DefendingArmy)
                .ThenInclude(da => da.Units)
                .ThenInclude(units => units.Type)
                .Single();

            //var users =
            //    db.Users.Include(user => user.Country)
            //    .ThenInclude(country => country.AttackingArmy)
            //    .ThenInclude(aa => aa.Units)
            //    .ThenInclude(units => units.Type)
            //    .Include(user => user.Country)
            //    .ThenInclude(country => country.DefendingArmy)
            //    .ThenInclude(da => da.Units)
            //    .ThenInclude(units => units.Type);

            foreach (var user in game.Users)
            {
                var removeUnits = user.Country.PayUnits();
                //RemoveUnitsFromAttackingList(removeUnits, user);
                var userAttacks = game.Attacks.Where(attack => attack.AttackerUser.Id == user.Id);
                bool stop = false;
                while (!stop)
                {
                    foreach (Attack attack in userAttacks)
                    {
                        foreach (int unitId in removeUnits.Keys)
                        {
                            var unitToRemove = attack.UnitList.Find(unit => unit.Id == unitId);
                            if (unitToRemove.Count > 0 && removeUnits[unitId] > 0)
                            {
                                removeUnits[unitId]--;
                                unitToRemove.Count--;
                            }
                        }
                        stop = removeUnits.Values.All(count => count == 0);
                        if (stop)
                        {
                            break;
                        }
                    }
                }
            }
            await db.SaveChangesAsync();
        }

        private void RemoveUnitsFromAttackingList(Dictionary<int, int> removeUnits, User user)
        {
            var game = db.Game.Single();
            var userAttacks = game.Attacks.Where(attack => attack.AttackerUser.Id == user.Id);
            bool stop = false;
            while (!stop)
            {
                foreach (Attack attack in userAttacks)
                {
                    foreach (int unitId in removeUnits.Keys)
                    {
                        var unitToRemove = attack.UnitList.Find(unit => unit.Id == unitId);
                        if (unitToRemove.Count > 0 && removeUnits[unitId] > 0)
                        {
                            removeUnits[unitId]--;
                            unitToRemove.Count--;
                        }
                    }
                    stop = removeUnits.Values.All(count => count == 0);
                    if (stop)
                    {
                        break;
                    }
                }
            }
        }

        private async Task Build()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings);
            foreach (var user in users)
            {
                user.Country.Build();
            }
            await db.SaveChangesAsync();
        }

        private async Task CalculateRankings()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings)
                .ThenInclude(b=>b.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.Upgrades);
            foreach (var user in users)
            {
                user.Score = user.Country.CalculateScore();
            }
            users.OrderByDescending(user => user.Score);
            int rank = 1;
            foreach (var user in users)
            {
                user.Place = ++rank;
            }
            await  db.SaveChangesAsync();
        }
    }
}
