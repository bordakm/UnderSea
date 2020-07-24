using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class LaserShark : UnitType
    {
        public LaserShark()
        {
            Name = "Lézercápa";
            ImageUrl = "/images/units/shark.png";
            Price = 100;
            PearlCostPerTurn = 3;
            CoralCostPerTurn = 2;
            Score = 10;
        }
    }
}
