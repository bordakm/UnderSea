using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSeaModel.Models.Units;

namespace UnderSeaModel.Model
{
    public class UnitGroup
    {
        public StormSeal StormSeal { get; set; }
        public CombatSeaHorse CombatSeaHorse { get; set; }
        public LaserShark LaserShark { get; set; }
    }
}
