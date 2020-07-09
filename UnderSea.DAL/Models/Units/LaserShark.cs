using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class LaserShark : Unit
    {
        public LaserShark()
        {
            Count = 0;
            Price = 100;
            AttackScore = 5.0;
            DefenseScore = 5.0;
            PearlCostPerTurn = 3;
            CoralCostPerTurn = 2;
        }
    }
}
