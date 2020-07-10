using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public abstract class UnitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public double AttackScore { get; set; }
        public double DefenseScore { get; set; }
        public int PearlCostPerTurn { get; set; }
        public int CoralCostPerTurn { get; set; }
        public string ImageUrl { get; set; }
    }
}
