using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class LaserShark : UnitType
    {
        public LaserShark()
        {
            Price = 100;
            AttackScore = 5.0;
            DefenseScore = 5.0;
            PearlCostPerTurn = 3;
            CoralCostPerTurn = 2;
        }

        public override int CalculateScore()
        {
            return Count * 10;
        }
    }
}
