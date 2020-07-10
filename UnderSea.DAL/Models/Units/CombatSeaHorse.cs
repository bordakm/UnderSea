using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class CombatSeaHorse : UnitType
    {
        public CombatSeaHorse()
        {            
            Price = 50;
            AttackScore = 2.0;
            DefenseScore = 6.0;
            PearlCostPerTurn = 1;
            CoralCostPerTurn = 1;
        }

        public override int CalculateScore()
        {
            return Count * 5;
        }
    }
}
