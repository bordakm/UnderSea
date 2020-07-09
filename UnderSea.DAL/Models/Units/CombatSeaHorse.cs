using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class CombatSeaHorse : Unit
    {
        public CombatSeaHorse()
        {
            Count = 0;
            Price = 50;
            AttackScore = 2.0;
            DefenseScore = 6.0;
            PearlCostPerTurn = 1;
            CoralCostPerTurn = 1;
        }
    }
}
