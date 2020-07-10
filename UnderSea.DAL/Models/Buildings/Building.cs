using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public abstract class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int PopulationBonus { get; set; }
        public int CoralBonus { get; set; }
        public int UnitStorage { get; set; }
        public int UnderConstructionCount { get; set; }
        public int ConstructionTimeLeft { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public int CoralBonusTotal => CoralBonus * (Count - UnderConstructionCount);

        [NotMapped]
        public int Score => Count * 50;
    }
}
