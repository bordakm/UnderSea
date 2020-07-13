using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class FlowManager : BuildingType
    {
        public FlowManager()
        {
            Name = "folyamirányító";
            Price = 1000;
            PopulationBonus = 50;
            CoralBonus = 200;
            UnitStorage = 0;
        }
    }
}
