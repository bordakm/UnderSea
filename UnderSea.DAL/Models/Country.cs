using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;
using UnderSea.DAL.Models.Upgrades;

namespace UnderSea.DAL.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BuildingGroup BuildingGroup { get; set; }
        public UnitGroup Army { get; set; }
        public int Coral { get; set; }
        public int CoralProduction { get; set; }
        public int Pearl { get; set; }
        public int PearlProduction { get; set; }

        public int Population { get; set; }
        public int UnitStorage { get; set; }
        public int TaxRate { get; set; }

        public List<Upgrade> Upgrades { get; set; } = new List<Upgrade> { new Alchemy(),
                                                                          new CoralWall(),
                                                                          new MudHarvester(),
                                                                          new MudTractor(),
                                                                          new SonarCannon(),
                                                                          new UnderwaterMartialArts()};


        public int UpgradeTimeLeft { get; set; }
        public int BuildingTimeLeft { get; set; }
        public int Score { get; set; }
    }
}
