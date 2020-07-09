using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public abstract class Building
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int PopulationBonus { get; set; }
        public int CoralBonus { get; set; }
        public int UnitStorage { get; set; }
        public int UnderConstructionCount { get; set; }
    }
}
