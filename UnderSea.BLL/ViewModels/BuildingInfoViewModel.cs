using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class BuildingInfoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int PearlPrice { get; set; }
        public int StonePrice { get; set; }
        public string ImageUrl { get; set; }
        public int RemainingRounds { get; set; }
    }
}
