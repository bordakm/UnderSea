using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models.Units
{
    public class UnitGroup
    {
        public int Id { get; set; }

        public List<Unit> Units { get; set; }
    }
}
