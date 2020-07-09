using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public abstract class Upgrade
    {
        public int CoralProductionBonusPercentage { get; set; }
        public int DefenseBonusPercentage { get; set; }
        public int AttackBonusPercentage { get; set; }
        public int AttackAndDefenseBonusPercentage { get; set; }
        public int PearlProductionBonusPercentage { get; set; }
        public UpgradeState State { get; set; }
    }
}
