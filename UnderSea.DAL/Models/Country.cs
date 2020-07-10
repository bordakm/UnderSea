using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public int CoralProduction { get; set; }
        public int Pearl { get; set; }
        public int PearlProduction { get; set; }
        public int Population { get; set; }
        public int UnitStorage { get; set; }
        public int TaxRate { get; set; }
        public User User { get; set; }
        public int UpgradeTimeLeft { get; set; }
        public int BuildingTimeLeft { get; set; }
        public int Score { get; set; }
        public List<Upgrade> Upgrades { get; set; } = new List<Upgrade>() { new Upgrade() { Type=new Alchemy(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new CoralWall(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new MudHarvester(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new SonarCannon(),State = UpgradeState.Unresearched},
                                                                            new Upgrade() { Type=new UnderwaterMartialArts(),State = UpgradeState.Unresearched},
        };

        public void AddTaxes()
        {
            Pearl += Population * 25;
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

            if(Coral >= totalCoralCost)
            {
                Coral -= totalCoralCost;
            }
            else
            {
                int difference = totalCoralCost - Coral;

                while(difference > 0)
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
                        if(item.Count > 0)
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
        public void DoUpgrades()
        {
            if (Upgrades.Any(u => u.State == UpgradeState.InProgress))
            {
                UpgradeTimeLeft--;
                if (UpgradeTimeLeft <= 0)
                {
                    var upgrade = Upgrades.FirstOrDefault(u => u.State == UpgradeState.InProgress);
                    upgrade.State = UpgradeState.Researched;
                }

            }
        }

    }
}
