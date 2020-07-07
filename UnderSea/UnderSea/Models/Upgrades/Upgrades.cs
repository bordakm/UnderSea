using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSeaModel.Models;

namespace UnderSeaModel.Model
{
    public class Upgrades
    {   
        public UpgradeStates MudTractor { get; set; }
        public UpgradeStates MudHarvester { get; set; }
        public UpgradeStates CoralWall { get; set; }
        public UpgradeStates SonarCannon { get; set; }
        public UpgradeStates UnderwaterMartialArts { get; set; }
        public UpgradeStates Alchemy { get; set; }
    }
}
