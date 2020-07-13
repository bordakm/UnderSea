using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.DAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BuildingGroup BuildingGroup { get; set; }
        public List<Unit> AttackingArmy { get; set; }
        public List<Unit> DefendingArmy { get; set; }
        public int Coral { get; set; }

        [NotMapped]
        public int CoralProduction
        {
            get
            {
                return BuildingGroup.Buildings.Sum(building => building.Count * building.Type.CoralBonus);
            }
        }
        public int Pearl { get; set; }

        [NotMapped]
        public int PearlProduction => Population * taxRate;

        [NotMapped]
        public int Population => BuildingGroup.Buildings.Sum(building => building.Type.PopulationBonus);

        [NotMapped]
        public int UnitStorage => BuildingGroup.Buildings.Sum(building => building.Type.UnitStorage);
        
        public User User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public int UpgradeTimeLeft { get; set; }
        public int BuildingTimeLeft { get; set; }
        public int Score { get; set; }
        public List<Upgrade> Upgrades { get; set; } = new List<Upgrade>() { new Upgrade() { Type=new Alchemy(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new CoralWall(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new MudHarvester(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new SonarCannon(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new UnderwaterMartialArts(),State = UpgradeState.Unresearched},
        };

        private readonly int taxRate = 25;

        public void AddTaxes()
        {
            Pearl += PearlProduction;
        }

        public void AddCoral()
        {
            int producedCoral = 0;
            BuildingGroup.Buildings.ForEach(building =>
            {
                producedCoral += building.CoralBonusTotal;
            });
            Coral += producedCoral;
        }

        public void FeedUnits()
        {
            int totalCoralCost = 0;
            AttackingArmy.ForEach(unit =>
            {
                totalCoralCost += unit.Type.CoralCostPerTurn;
            });

            DefendingArmy.ForEach(unit =>
            {
                totalCoralCost += unit.Type.CoralCostPerTurn;
            });

            if (Coral >= totalCoralCost)
            {
                Coral -= totalCoralCost;
            }
            else
            {
                int difference = totalCoralCost - Coral;

                while (difference > 0)
                {
                    foreach (var item in DefendingArmy)
                    {
                        if (item.Count > 0)
                        {
                            if (difference <= 0)
                                break;
                            difference -= item.Type.CoralCostPerTurn;
                            item.Count--;
                        }

                    }

                    foreach (var item in AttackingArmy)
                    {
                        if (item.Count > 0)
                        {
                            if (difference <= 0)
                                break;
                            difference -= item.Type.CoralCostPerTurn;
                            item.Count--;
                        }

                    }
                }
            }
        }

        public Dictionary<int, int> PayUnits()
        {
            Dictionary<int, int> unitsToRemove = new Dictionary<int, int>();
            int costTotal = AttackingArmy.Sum(unit => unit.Count * unit.Type.PearlCostPerTurn);
            costTotal += DefendingArmy.Sum(unit => unit.Count * unit.Type.PearlCostPerTurn);
            int difference = Pearl - costTotal;
            if (difference < 0)
            {
                unitsToRemove = FireUnits(Math.Abs(difference));
                costTotal = AttackingArmy.Sum(unit => unit.Count * unit.Type.PearlCostPerTurn)
                          + DefendingArmy.Sum(unit => unit.Count * unit.Type.PearlCostPerTurn);
            }
            Pearl -= costTotal;
            return unitsToRemove;
        }

        private Dictionary<int, int> FireUnits(int difference)
        {
            Dictionary<int, int> unitsToRemove = new Dictionary<int, int>();
            foreach (Unit unit in AttackingArmy)
            {
                unitsToRemove.Add(unit.Id, 0);
            }
            bool stop = false;
            while (!stop)
            {
                foreach (Unit unit in DefendingArmy)
                {
                    if (unit.Count > 0)
                    {
                        unit.Count--;
                        difference -= unit.Type.PearlCostPerTurn;
                        if (difference <= 0)
                        {
                            stop = true;
                            break;                            
                        }
                    }
                }
                if (stop)
                {
                    break;
                }
                foreach (Unit unit in AttackingArmy)
                {
                    if (unit.Count > 0)
                    {
                        unitsToRemove[unit.Id]++;
                        unit.Count--;
                        difference -= unit.Type.PearlCostPerTurn;
                        if (difference <= 0)
                        {
                            stop = true;
                            break;
                        }
                    }
                }
            }
            return unitsToRemove;
        }

        public void Build()
        {
            var buildings = BuildingGroup.Buildings;
            foreach (Building building in buildings)
            {
                if (building.UnderConstructionCount > 0 && BuildingTimeLeft > 0)
                {
                    BuildingTimeLeft--;
                    if (BuildingTimeLeft == 0)
                    {
                        building.Count++;
                        building.UnderConstructionCount--;
                    }
                }                
            }
        }

        public int CalculateScore()
        {
            int score = 0;
            score += Population;
            foreach (Building building in BuildingGroup.Buildings)
            {
                score += building.Type.Score;
            }
            foreach (Unit unit in AttackingArmy)
            {
                score += unit.CalculateScore();
            }
            foreach (Unit unit in DefendingArmy)
            {
                score += unit.CalculateScore();
            }
            foreach (Upgrade upgrade in Upgrades)
            {
                if (upgrade.State == UpgradeState.Researched)
                {
                    score += 100;
                }
            }
            return score;
        }
        public void DoUpgrades()
        {
            if (Upgrades.Any(u => u.State == UpgradeState.InProgress))
            {
                UpgradeTimeLeft--;
                if (UpgradeTimeLeft <= 0)
                {
                    var upgrade = Upgrades.Single(u => u.State == UpgradeState.InProgress);
                    upgrade.State = UpgradeState.Researched;
                }

            }
        }

    }
}
