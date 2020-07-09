using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class AvailableUnitViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableCount { get; set; }
        public string Picture { get; set; }
    }
}
