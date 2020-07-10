using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class Unit
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public UnitType Type { get; set; }
    }
}
