using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class FlowManager : BuildingType
    {
        public FlowManager()
        {
            Name = "Áramlásirányító";
            Description = "200 egységnek nyújt szállást";
            ImageUrl = "/images/buildings/flowmanager.png";
            Price = 1000;
            PopulationBonus = 50;
            CoralBonus = 200;
            UnitStorage = 0;
            Score = 50;
        }
    }
}
