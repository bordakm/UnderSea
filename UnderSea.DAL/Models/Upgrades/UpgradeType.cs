using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public abstract class UpgradeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int CoralProductionBonusPercentage { get; set; }
        public int DefenseBonusPercentage { get; set; }
        public int AttackBonusPercentage { get; set; }
        public int AttackAndDefenseBonusPercentage { get; set; }
        public int PearlProductionBonusPercentage { get; set; }
    }
}
