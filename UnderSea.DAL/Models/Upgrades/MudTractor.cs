using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class MudTractor : UpgradeType
    {
        public MudTractor()
        {
            Name = "Iszaptraktor";
            Description = "növeli a korall termesztést 10%-kal";
            ImageUrl = "/images/upgrades/mudtractor.png";
            CoralProductionBonusPercentage = 10;
        }
    }
}
