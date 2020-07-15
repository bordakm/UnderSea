using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class ReefCastle : BuildingType
    {
        public ReefCastle()
        {
            Name = "Zátonyvár";
            Description = "50 ember-t ad a népességhez, 200 krumplit termel körönként";
            ImageUrl = "majd/lesz/kep.jpeg";
            Price = 1000;
            PopulationBonus = 0;
            CoralBonus = 0;
            UnitStorage = 200;
        }
    }
}
