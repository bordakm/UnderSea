using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.ViewModels
{
    public class StatusBarViewModel
    {
        public IEnumerable<Unit> Units { get; set; }
        public BuildingGroup Buildings { get; set; }
        public int RoundCount { get; set; }
        public int ScoreboardPosition { get; set; }
        public StatusBarResource Resources { get; set; }

        public class StatusBarBuilding
        {
            public int Id { get; set; }
            public string Icon { get; set; }
            public int Count { get; set; }
            public int UnderConstructionCount { get; set; }
        }

        public class StatusBarUnit
        {
            public int Id { get; set; }
            public int AvailableCount { get; set; }
            public string Picture { get; set; }
        }

        public class StatusBarResource
        {
            public int PearlCount { get; set; }
            public int PearlProductionCount { get; set; }
            public string PearlPictureUrl { get; set; }
            public int CoralCount { get; set; }
            public int CoralProductionCount { get; set; }
            public string CoralPictureUrl { get; set; }
        }
    }
}
