using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;
using UnderSea.BLL.ViewModels;
using UnderSea.DAL.Context;
using UnderSea.DAL.Models;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.Services
{
    public class ArmyService : IArmyService
    {
        private readonly UnderSeaDbContext db;
        private readonly IMapper mapper;
        public ArmyService(UnderSeaDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<SimpleUnitViewModel>> AttackAsync(int attackerUserId, AttackDTO attack)
        {
            var game = await db.Game
                .Include(game => game.Attacks)
                .SingleAsync();
            var unitTypes = await db.UnitTypes.ToListAsync();
            var attackingUser = await db.Users
                .Include(u => u.Country)
                .ThenInclude(country => country.DefendingArmy)
                .ThenInclude(defendingArmy => defendingArmy.Units)
                .ThenInclude(unit => unit.Type)
                .ThenInclude(type => type.Levels)
                .Include(u => u.Country)
                .ThenInclude(country => country.AttackingArmy)
                .ThenInclude(attackingArmy => attackingArmy.Units)
                .ThenInclude(unit => unit.Type)
                .ThenInclude(type => type.Levels)
                .SingleAsync(u => u.Id == attackerUserId);
            var defendingCountry = await db.Countries
                .Include(country => country.User)
                .SingleAsync(c => c.UserId == attack.DefenderUserId);
            var defendingUser = defendingCountry.User;

            var tranferList = new List<Unit>();

            await db.SaveChangesAsync();

            foreach (var sendUnit in attack.AttackingUnits)
            {
                int ownedCount = attackingUser.Country.DefendingArmy.Units
                    .Count(u => u.Type.Id == sendUnit.Id && u.Level == sendUnit.Level);
                if (sendUnit.SendCount > ownedCount)
                    throw new HttpResponseException { Status = 400, Value = "Nem küldhetsz több egységet, mint amennyid van!" };
                else
                {
                    //Összeszedjük a kívánt egységeket a defending armyból
                    foreach (var oneAttack in attack.AttackingUnits)
                    {
                        foreach (var defender in attackingUser.Country.DefendingArmy.Units)
                        {
                            if(defender.Type.Id == oneAttack.Id
                                //Group by LVL
                                && defender.Level == oneAttack.Level)
                            {
                                oneAttack.SendCount--;
                                tranferList.Add(defender);
                            }

                            if (oneAttack.SendCount <= 0)
                                break;
                        }
                    }

                    // levonjuk az egységeket a defending armyból
                    // ÉS hozzáadjuk az attacking armyhoz
                    foreach (var item in tranferList)
                    {
                        attackingUser.Country.DefendingArmy.Units.Remove(item);
                        item.UnitGroupId = attackingUser.Country.AttackingArmyId;
                        attackingUser.Country.AttackingArmy.Units.Add(item);
                    }

                }
            }

            game.Attacks.Add(new Attack
            {
                AttackerUserId = attackingUser.Id,
                AttackerUser = attackingUser,
                DefenderUserId = defendingUser.Id,
                DefenderUser = defendingUser,
                GameId = game.Id,
                UnitList = tranferList
            });
            await db.SaveChangesAsync();

            List<SimpleUnitViewModel> result = new List<SimpleUnitViewModel>();
            var found = false;
            foreach (var unit in tranferList)
            {
                found = false;

                foreach (var unitvm in result)
                {
                    if (unitvm.TypeId == unit.Type.Id
                        //Group by LVL
                        && unitvm.Level == unit.Level)
                    {
                        unitvm.Count++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    result.Add(new SimpleUnitViewModel()
                    {
                        Count = 1,
                        Level = unit.Level,
                        TypeId = unit.Type.Id                        
                    });
                }

            }

            return result;
        }

        public async Task<IEnumerable<SimpleUnitViewModel>> BuyUnitsAsync(int userId, List<UnitPurchaseDTO> purchases)
        {
            //TODO optimalizálás
            var user = await db.Users.Include(user => user.Country)
                                    .ThenInclude(country => country.BuildingGroup)
                                    .ThenInclude(bg => bg.Buildings)
                                    .ThenInclude(buildings => buildings.Type)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.AttackingArmy)
                                    .ThenInclude(aa => aa.Units)
                                    .ThenInclude(units => units.Type)
                                    .ThenInclude(type => type.Levels)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.DefendingArmy)
                                    .ThenInclude(da => da.Units)
                                    .ThenInclude(units => units.Type)
                                    .ThenInclude(type => type.Levels)
                                    .Include(user => user.Country)
                                    .ThenInclude(country => country.Upgrades)
                                    .ThenInclude(upgrades => upgrades.Type)
                                    .FirstAsync(user => user.Id == userId);

            var attackingUnits = user.Country.AttackingArmy.Units;
            var defendingUnits = user.Country.DefendingArmy.Units;
            int currentUnitCount = attackingUnits.Sum(unit => 1) + defendingUnits.Sum(unit => 1);
            int plusUnitCount = purchases.Sum(purchase => purchase.Count);
            if (user.Country.UnitStorage < currentUnitCount + plusUnitCount)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs elég helyed a barrakkodban!" };
            }
            int priceTotal = purchases.Sum(purchase => purchase.Count * defendingUnits.Single(unit => unit.Type.Id == purchase.TypeId).Type.Price);
            if (priceTotal > user.Country.Pearl)
            {
                throw new HttpResponseException { Status = 400, Value = "Nincs eléd gyöngyöd!" };
            }
            user.Country.Pearl -= priceTotal;

            foreach (var purUnit in purchases)
            {
                for(int i = 0; i<purUnit.Count; i++)
                {
                    defendingUnits.Add(new Unit
                    {
                        BattlesSurvived = 0,
                        TypeId = purUnit.TypeId,
                        UnitGroupId = user.Country.DefendingArmyId
                    });
                }
            }

            await db.SaveChangesAsync();
            var result = mapper.Map<List<UnitPurchaseDTO>, IEnumerable<SimpleUnitViewModel>>(purchases);
            foreach (var unit in result)
            {
                unit.Level = 1;
            }
            return result;
        }

        public async Task<IEnumerable<AvailableUnitViewModel>> GetAvailableUnitsAsync(int userId)
        {
            var user = await db.Users
                               .Include(user => user.Country)
                               .ThenInclude(country => country.DefendingArmy)
                               .ThenInclude(army => army.Units)
                               .ThenInclude(unit => unit.Type)
                               .ThenInclude(type => type.Levels)
                               .SingleAsync(user => user.Id == userId);

            var units = user.Country.DefendingArmy.Units;
            List<AvailableUnitViewModel> result = new List<AvailableUnitViewModel>();
            var found = false;
            foreach (var unit in units)
            {
                found = false;

                foreach (var unitvm in result)
                {
                    if (unitvm.Id == unit.Type.Id
                        //Group by LVL
                        && unitvm.Level == unit.Level)
                    {
                        unitvm.AvailableCount++;
                        unitvm.AllCount++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    result.Add(new AvailableUnitViewModel()
                    {
                        AvailableCount = 1,
                        AllCount = 1,
                        Id = unit.Type.Id,
                        ImageUrl = unit.Type.ImageUrl,
                        Level = unit.Level,
                        Name = unit.Type.Name
                    });
                }
                    
            }
            
            return result;
        }

        public async Task<IEnumerable<OutgoingAttackViewModel>> GetOutgoingAttacksAsync(int userId)
        {
            var attacks = await db.Attacks
                               .Include(attack => attack.UnitList)
                               .ThenInclude(u => u.Type)
                               .ThenInclude(type => type.Levels)
                               .Include(attack => attack.AttackerUser)
                               .ThenInclude(attacker => attacker.Country)
                               .Include(attack => attack.DefenderUser)
                               .ThenInclude(du => du.Country)
                               .Where(attacks => attacks.AttackerUser.Id == userId)
                               .ToListAsync();

            var response = new List<OutgoingAttackViewModel>();
            var result = new List<SimpleUnitWithNameViewModel>();
            var found = false;
            foreach (var attack in attacks)
            {
                result.Clear();
                found = false;
                foreach (var unit in attack.UnitList)
                {
                    found = false;

                    foreach (var unitvm in result)
                    {
                        if (unitvm.TypeId == unit.Type.Id
                            //Group by LVL
                            && unit.Level == unit.Level)
                        {
                            unitvm.Count++;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        result.Add(new SimpleUnitWithNameViewModel()
                        {
                            Count = 1,
                            TypeId = unit.Type.Id,
                            Name = unit.Type.Name,
                            Level = unit.Level
                        });
                    }                    
                }

                response.Add(new OutgoingAttackViewModel
                {
                    CountryName = attack.DefenderUser.Country.Name,
                    Units = result
                });
            }
            return response;
        }


        //TODO
        public async Task<IEnumerable<UnitViewModel>> GetUnitsAsync(int userId)
        {
            var country = await db.Countries.SingleAsync(c => c.UserId == userId);
            var units = db.Units.Where(u => u.UnitGroupId == country.DefendingArmyId)
                                .Include(u => u.Type)
                                .ThenInclude(t => t.Levels);
            var levels = db.UnitLevels.ToList();
            var unitTypes = db.UnitTypes.ToList();



            List<UnitViewModel> result = new List<UnitViewModel>();
            foreach (var unit in unitTypes)
            {
                result.Add(new UnitViewModel()
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    Count = 0,
                    Level = 1,
                    ImageUrl = unit.ImageUrl,
                    CoralCostPerTurn = unit.CoralCostPerTurn,
                    PearlCostPerTurn = unit.PearlCostPerTurn,
                    Price = unit.Price
                });
            }

            foreach (var unit in units)
            {
                foreach (var unitvm in result)
                {
                    if (unitvm.Id == unit.Type.Id)
                    {
                        unitvm.Count++;
                    }
                }
            }

            foreach (var level in levels)
            {
                foreach (var unit in result)
                {
                    if(level.UnitTypeId == unit.Id 
                        && level.Level == 1
                        )
                    {
                        unit.AttackScore = level.AttackScore;
                        unit.DefenseScore = level.DefenseScore;
                    }
                }
            }

            return result;
        }
    }
}
