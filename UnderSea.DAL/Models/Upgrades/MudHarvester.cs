using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class MudHarvester : Upgrade
    {
        public MudHarvester()
        {
            CoralProductionBonusPercentage = 15;
        }
    }
}
