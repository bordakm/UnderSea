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
            Description = "50 népességet ad és körönként 200 korallt termel";
            ImageUrl = "/images/buildings/flowmanager.png";
            SmallIconUrl = "/images/buildings/flowmanagericon.png";
            Price = 1000;
            PopulationBonus = 50;
            CoralBonus = 200;
            UnitStorage = 0;
            Score = 50;
        }
    }
}
