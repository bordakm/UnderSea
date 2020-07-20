using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Upgrades;
using UnderSea.BLL.Hubs;

namespace UnderSea.BLL.Services
{
    public class GameService : IGameService
    {
        private UnderSeaDbContext db;
        private readonly IMapper mapper;
        private readonly IHubContext<MyHub> hubContext;
        public GameService(UnderSeaDbContext db, IMapper mapper, IHubContext<MyHub> hubContext)
        {
            this.db = db;
            this.mapper = mapper;
            this.hubContext = hubContext;
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
                                .ThenInclude(u => u.Type)
                                .SingleAsync(user => user.Id == userId);


            MainPageViewModel response = new MainPageViewModel()
            {
                CountryName = user.Country.Name,
                StatusBar = new StatusBarViewModel
                {
                    Buildings = mapper.Map<IEnumerable<StatusBarViewModel.StatusBarBuilding>>(user.Country.BuildingGroup.Buildings),
                    RoundCount = game.Round,
                    ScoreboardPosition = user.Place,
                    Units = mapper.Map<IEnumerable<AvailableUnitViewModel>>(user.Country.DefendingArmy.Units),
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
            return response;
        }

        public async Task NewRoundAsync(int rounds = 1)
        {
            for (int i = 0; i < rounds; ++i)
            {
                using (var tran = db.Database.BeginTransaction())
                {
                    await AddTaxes();
                    await AddCoral();
                    await PayUnits();
                    await FeedUnits();
                    await DoUpgrades();
                    await Build();
                    await CalculateAttacks();
                    await CalculateRankingsAsync();
                    tran.Commit();
                }
            }
            await hubContext.Clients.All.SendAsync("NewRound");
        }

        public async Task<IEnumerable<ScoreboardViewModel>> SearchScoreboardAsync(SearchDTO search)
        {
            int perPage = search.ItemPerPage ?? 10;
            int pageNum = search.Page ?? 1;
            string searchWord = search.SearchPhrase ?? "";
            var users = await db.Users
                               .Where(users => searchWord.ToUpper().Contains(searchWord.ToUpper()))
                               .Skip(perPage * (pageNum - 1))
                               .Take(perPage)
                               .ToListAsync();
            return mapper.Map<IEnumerable<ScoreboardViewModel>>(users);
        }

        public async Task CalculateRankingsAsync()
        {
            var users = db.Users.Include(user => user.Country)
                .ThenInclude(country => country.BuildingGroup)
                .ThenInclude(buildingGroup => buildingGroup.Buildings)
                .ThenInclude(b => b.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.Upgrades)
                .ThenInclude(upgrades => upgrades.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.AttackingArmy)
                .ThenInclude(aa => aa.Units)
                .ThenInclude(units => units.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.DefendingArmy)
                .ThenInclude(da => da.Units)
                .ThenInclude(units => units.Type);

            foreach (var user in users)
            {
                user.Score = user.Country.CalculateScore();
            }
            users.OrderByDescending(user => user.Score);
            int rank = 1;
            foreach (var user in users)
            {
                user.Place = rank++;
            }
            await db.SaveChangesAsync();
        }

        private async Task AddTaxes()
        {
            var users = db.Users
                .Include(user => user.Country)
                .ThenInclude(c => c.BuildingGroup)
                .ThenInclude(bg => bg.Buildings)
                .ThenInclude(b => b.Type)
                .Include(user => user.Country)
                .ThenInclude(country => country.Upgrades)
                .ThenInclude(upgrade => upgrade.Type);
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
                .ThenInclude(buildingGroup => buildingGroup.Buildings)
                .ThenInclude(buildig => buildig.Type);

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
                var userAttacks = game.Attacks.Where(attack => attack.AttackerUser.Id == user.Id);
                bool stop = false;
                while (!stop && userAttacks.Count() != 0)
                {
                    foreach (Attack attack in userAttacks)
                    {
                        foreach (int unitId in removeUnits.Keys)
                        {
                            var unitToRemove = attack.UnitList.Find(unit => unit.Type.Id == unitId);
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
            var game = await db.Game
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
                .SingleAsync();

            foreach (var user in game.Users)
            {
                var removeUnits = user.Country.PayUnits();
                var userAttacks = game.Attacks.Where(attack => attack.AttackerUser.Id == user.Id);
                bool stop = false;
                while (!stop && userAttacks.Count() != 0)
                {
                    foreach (Attack attack in userAttacks)
                    {
                        foreach (int unitId in removeUnits.Keys)
                        {
                            var unitToRemove = attack.UnitList.Find(unit => unit.Type.Id == unitId);
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
    }
}
