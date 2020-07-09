using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class StormSeal : Unit
    {
        public StormSeal() 
        {
            Count = 0;
            Price = 50;
            AttackScore = 6.0;
            DefenseScore = 2.0;
            PearlCostPerTurn = 1;
            CoralCostPerTurn = 1;
        }
    }
}
