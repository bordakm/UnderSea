using System;
using System.Collections.Generic;
using System.Text;
using UnderSeaModel.Model;

namespace UnderSeaModel.Models.Units
{
    public class StormSeal
    {
        public int Count { get; set; }
        public int Price { get; set; }
        public double AttackScore { get; protected set; }
        public double DefenseScore { get; protected set; }
        public int PearlCostPerTurn { get; protected set; }
        public int CoralCostPerTurn { get; protected set; }
    }
}
