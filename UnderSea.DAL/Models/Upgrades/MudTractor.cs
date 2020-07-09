using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class MudTractor : Upgrade
    {
        public MudTractor()
        {
            Name = "Iszaptraktor";
            Description = "növeli a krumpli termesztést 10%-kal";
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            CoralProductionBonusPercentage = 10;
        }
    }
}
