using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class MudHarvester : UpgradeType
    {
        public MudHarvester()
        {
            Name = "Iszapkombájn";
            Description = "növeli a korall termesztést 15%-kal";
            ImageUrl = "/images/upgrades/mudharvester.png";
            CoralProductionBonusPercentage = 15;
        }
    }
}
