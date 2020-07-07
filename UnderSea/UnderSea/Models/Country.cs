using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSeaModel.Models;
using UnderSeaModel.Models.Buildings;

namespace UnderSeaModel.Model
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

        public Upgrades Upgrades { get; set; }
        
        public int UpgradeTimeLeft { get; set; }
        public int BuildingTimeLeft { get; set; }

        public int Score { get; set; }


    }
}
