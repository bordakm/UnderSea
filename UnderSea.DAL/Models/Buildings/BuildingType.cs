using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public abstract class BuildingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int PopulationBonus { get; set; }
        public int CoralBonus { get; set; }
        public int UnitStorage { get; set; }
        public string ImageUrl { get; set; }
        public string SmallIconUrl { get; set; }
        public int Score { get; set; }
    }
}
