using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int Level { get; set; }
        public double AttackScore { get; set; }
        public double DefenseScore { get; set; }
        public int PearlCostPerTurn { get; set; }
        public int CoralCostPerTurn { get; set; }
        public int Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
