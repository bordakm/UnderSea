using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class StoneMine : BuildingType
    {
        public StoneMine()
        {
            Name = "Kőbánya";
            Description = "25 követ termel körönként";
            ImageUrl = "/images/buildings/stonemine.png";
            SmallIconUrl = "/images/buildings/stonemineicon.png";
            Price = 1000;
            BuildingTime = 5;
            StoneBonus = 25;
            Score = 50;
        }
    }
}
