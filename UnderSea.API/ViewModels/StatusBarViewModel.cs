using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API.ViewModels
{
    public class StatusBarViewModel
    {
        public StatusBarUnit CombatSeaHorse { get; set; }
        public StatusBarUnit LaserShark { get; set; }
        public StatusBarUnit StromSeal { get; set; }
        public StatusBarBuilding FlowManager { get; set; }
        public StatusBarBuilding ReefCastle { get; set; }
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
            public string PearlPicture { get; set; }
            public int CoralCount { get; set; }
            public int CoralProductionCount { get; set; }
            public string CoralPicture { get; set; }
        }
    }
}
