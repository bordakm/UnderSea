using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class Alchemy : Upgrade
    {
        public Alchemy() 
        {
            Name = "Alkímia";
            Description = "növeli a beszedett adót 30%-kal";
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            CoralProductionBonusPercentage = 30;
        }
    }
}
