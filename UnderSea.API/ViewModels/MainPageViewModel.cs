using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.API.DTO;

namespace UnderSea.API.ViewModels
{
    public class MainPageViewModel
    {
        public int RoundCount { get; set; }
        public int ScoreboardPosition { get; set; }
        public int LaserSharkCount { get; set; }
        public int StromSealCount { get; set; }
        public int CombatSeaHorseCount { get; set; }
        public int PearlCount { get; set; }
        public int PearlProductionCount { get; set; }
        public int CoralCount { get; set; }
        public int CoralProductionCount { get; set; }
        public string CountryName { get; set; }
        public StructuresDTO Structures { get; set; }
    }
}
