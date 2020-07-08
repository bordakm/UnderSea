using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API.ViewModels
{
    public class UnitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public int AttackScore { get; set; }
        public int DefenseScore { get; set; }
        public int Salary { get; set; }
        public int Price { get; set; }
    }
}
