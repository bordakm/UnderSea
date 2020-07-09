using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    public class CoralWall : Upgrade
    {
        public CoralWall()
        {
            Name = "Korallfal";
            Description = "növeli a védelmi pontokat 20%-kal";
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            DefenseBonusPercentage = 20;
        }
    }
}
