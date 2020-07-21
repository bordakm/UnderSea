﻿using System;
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
        private readonly int taxPerPerson = 25;
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("BuildingGroup")]
        public int BuildingGroupId { get; set; }
        public BuildingGroup BuildingGroup { get; set; }
        [ForeignKey("UnitGroup")]
        public int AttackingArmyId { get; set; }
        public UnitGroup AttackingArmy { get; set; }
        [ForeignKey("UnitGroup")]
        public int DefendingArmyId { get; set; }
        public UnitGroup DefendingArmy { get; set; }
        public int Coral { get; set; }
        public int Pearl { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int UpgradeTimeLeft { get; set; }
        public int BuildingTimeLeft { get; set; }
        public int Score { get; set; }
        public List<Upgrade> Upgrades { get; set; }
        [NotMapped]
        public int PearlProduction => Population * taxPerPerson * (1 + (Upgrades.Sum(upgrades => upgrades.Type.TaxBonusPercentage) / 100));
        [NotMapped]
        public int Population => BuildingGroup.Buildings.Sum(building => building.Type.PopulationBonus * building.Count);
        [NotMapped]
        public int UnitStorage => BuildingGroup.Buildings.Sum(building => building.Type.UnitStorage * building.Count);
        [NotMapped]
        public int CoralProduction
        {
            get
            {
                return BuildingGroup.Buildings.Sum(building => building.Count * building.Type.CoralBonus);
            }
        }
        public void AddTaxes()
        {
            Pearl += PearlProduction;
        }

        public void AddCoral()
        {
            Coral += CoralProduction;
        }

        public Dictionary<int, int> FeedUnits()
        {
            Dictionary<int, int> unitsToRemove = new Dictionary<int, int>();
            int costTotal = AttackingArmy.Units.Sum(unit => unit.Type.CoralCostPerTurn);
            costTotal += DefendingArmy.Units.Sum(unit => unit.Type.CoralCostPerTurn);
            int difference = Coral - costTotal;
            if (difference < 0)
            {
                unitsToRemove = FireUnits(Math.Abs(difference), FireReason.Coral);
                costTotal = AttackingArmy.Units.Sum(unit => unit.Type.CoralCostPerTurn)
                          + DefendingArmy.Units.Sum(unit => unit.Type.CoralCostPerTurn);
            }
            Coral -= costTotal;
            return unitsToRemove;
        }

        public Dictionary<int, int> PayUnits()
        {
            Dictionary<int, int> unitsToRemove = new Dictionary<int, int>();
            int costTotal = AttackingArmy.Units.Sum(unit => unit.Type.PearlCostPerTurn)
                          + DefendingArmy.Units.Sum(unit => unit.Type.PearlCostPerTurn);
            int difference = Pearl - costTotal;
            if (difference < 0)
            {
                unitsToRemove = FireUnits(Math.Abs(difference), FireReason.Pearl);
                costTotal = AttackingArmy.Units.Sum(unit => unit.Type.PearlCostPerTurn)
                          + DefendingArmy.Units.Sum(unit => unit.Type.PearlCostPerTurn);
            }
            Pearl -= costTotal;
            return unitsToRemove;
        }

        private Dictionary<int, int> FireUnits(int difference, FireReason fireReason)
        {
            Dictionary<int, int> unitsToRemove = new Dictionary<int, int>();
            foreach (Unit unit in AttackingArmy.Units)
            {
                unitsToRemove.Add(unit.Type.Id, 0);
            }
            bool stop = false;
            while (!stop)
            {
                foreach (Unit unit in DefendingArmy.Units)
                {
                    if (unit.Count > 0)
                    {
                        unit.Count--;
                        switch (fireReason)
                        {
                            case FireReason.Coral:
                                difference -= unit.Type.CoralCostPerTurn;
                                break;
                            case FireReason.Pearl:
                                difference -= unit.Type.PearlCostPerTurn;
                                break;
                        }
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
                foreach (Unit unit in AttackingArmy.Units)
                {
                    if (unit.Count > 0)
                    {
                        unitsToRemove[unit.Type.Id]++;
                        unit.Count--;
                        switch (fireReason)
                        {
                            case FireReason.Coral:
                                difference -= unit.Type.CoralCostPerTurn;
                                break;
                            case FireReason.Pearl:
                                difference -= unit.Type.PearlCostPerTurn;
                                break;
                        }
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
                score += building.Type.Score * building.Count;
            }

            foreach (Unit unit in AttackingArmy.Units)
            {
                score += unit.Type.Score;
            }
            foreach (Unit unit in DefendingArmy.Units)
            {
                score += unit.Type.Score;
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

    enum FireReason { Pearl, Coral }
}
