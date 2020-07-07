using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models.Units
{
    public class UnitGroup
    {
        public int Id { get; set; }
        public StormSeal StormSeal { get; set; }
        public CombatSeaHorse CombatSeaHorse { get; set; }
        public LaserShark LaserShark { get; set; }
    }
}
