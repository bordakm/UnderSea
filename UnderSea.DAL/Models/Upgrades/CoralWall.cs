using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class CoralWall : UpgradeType
    {
        public CoralWall()
        {
            Name = "Korallfal";
            Description = "növeli a védelmi pontokat 20%-kal";
            ImageUrl = "/images/upgrades/coralwall.png";
            DefenseBonusPercentage = 20;
        }
    }
}
