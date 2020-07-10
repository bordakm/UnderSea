using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class Building
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int UnderConstructionCount { get; set; }
        public int ConstructionTimeLeft { get; set; }
        public BuildingType Type { get; set; }

        [NotMapped]
        public int CoralBonusTotal => Type.CoralBonus * (Count - UnderConstructionCount);       
    }
}
