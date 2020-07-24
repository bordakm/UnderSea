using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class StormSeal : UnitType
    {
        public StormSeal()
        {
            Name = "Rohamfóka";
            ImageUrl = "/images/units/seal.png";
            Price = 50;
            PearlCostPerTurn = 1;
            CoralCostPerTurn = 1;
            Score = 5;
        }
    }
}
