using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{
    class UnderwaterMartialArts : Upgrade
    {
        public UnderwaterMartialArts() 
        {
            Name = "Vízalatti harcművészetek";
            Description = "növeli a védelmi és támadóerőt 10%-kal";
            ImageUrl = "majd/kesobb/lesz/kep.jpg";
            AttackAndDefenseBonusPercentage = 10;
        }
    }
}
