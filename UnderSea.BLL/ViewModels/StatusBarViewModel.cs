using System.Collections.Generic;
using UnderSea.DAL.Models.Buildings;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.ViewModels
{
    public class StatusBarViewModel
    {
        public IEnumerable<AvailableUnitViewModel> Units { get; set; }
        public IEnumerable<StatusBarBuilding> Buildings { get; set; }
        public int RoundCount { get; set; }
        public int ScoreboardPosition { get; set; }
        public IEnumerable<StatusBarResource> Resources { get; set; }

        public class StatusBarBuilding
        {
            public int TypeId { get; set; }
            public string ImageUrl { get; set; }
            public string Name { get; set; }
            public int Count { get; set; }
            public int UnderConstructionCount { get; set; }
        }

        public class StatusBarResource
        {
            public int Count { get; set; }
            public int ProductionCount { get; set; }
            public string PictureUrl { get; set; }
        }
    }
}
