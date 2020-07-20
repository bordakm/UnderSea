using System;
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
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            TaxBonusPercentage = 30;
        }
    }
}
