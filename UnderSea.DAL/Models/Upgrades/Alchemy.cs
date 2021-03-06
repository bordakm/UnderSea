﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class Alchemy : UpgradeType
    {
        public Alchemy()
        {
            Name = "Alkímia";
            Description = "növeli a beszedett adót 30%-kal";
            ImageUrl = "/images/upgrades/alchemy.png";
            PearlProductionBonusPercentage = 30;
        }
    }
}
