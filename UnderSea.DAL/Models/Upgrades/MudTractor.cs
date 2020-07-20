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
            Description = "növeli a krumpli termesztést 10%-kal";
            ImageUrl = "/images/valami.png";
            CoralProductionBonusPercentage = 10;
        }
    }
}
