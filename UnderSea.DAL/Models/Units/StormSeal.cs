using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class StormSeal
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public double AttackScore { get; set; }
        public double DefenseScore { get; set; }
        public int PearlCostPerTurn { get; set; }
        public int CoralCostPerTurn { get; set; }
    }
}
