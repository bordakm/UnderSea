using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class SonarCannon : UpgradeType
    {
        public SonarCannon()
        {
            Name = "Szonárágyú";
            Description = "növeli a támadópontokat 20%-kal";
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            AttackBonusPercentage = 20;
        }
    }
}
