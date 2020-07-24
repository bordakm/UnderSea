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
            Description = "200 egységnek nyújt szállást";
            ImageUrl = "/images/buildings/reefcastle.png";
            SmallIconUrl = "/images/buildings/reefcastleicon.png";
            Price = 1000;
            StonePrice = 50;
            BuildingTime = 5;
            PopulationBonus = 0;
            CoralBonus = 0;
            UnitStorage = 200;
            Score = 50;
        }
    }
}
