using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class FlowManager : Building
    {
        public FlowManager()
        {
            Count = 0;
            Name = "folyamirányító";
            Price = 1000;
            PopulationBonus = 50;
            CoralBonus = 200;
            UnitStorage = 0;
            UnderConstructionCount = 0;
        }
    }
}
