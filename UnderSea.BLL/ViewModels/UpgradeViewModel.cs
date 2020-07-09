using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class UpgradeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Picture { get; set; }
        public bool IsPurchased { get; set; }
        public int RemainingRounds { get; set; }
    }
}
