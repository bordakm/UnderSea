using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSeaModel.Models;

namespace UnderSeaModel.Model
{
    public class Upgrades
    {
        public int Id { get; set; }
        public UpgradeState MudTractor { get; set; }
        public UpgradeState MudHarvester { get; set; }
        public UpgradeState CoralWall { get; set; }
        public UpgradeState SonarCannon { get; set; }
        public UpgradeState UnderwaterMartialArts { get; set; }
        public UpgradeState Alchemy { get; set; }
    }
}
