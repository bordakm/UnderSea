using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class ReefCastle : Building
    {
        public ReefCastle()
        {
            Count = 0;
            Price = 1000;
            PopulationBonus = 0;
            CoralBonus = 0;
            UnitStorage = 200;
            UnderConstructionCount = false;
        }
    }
}
