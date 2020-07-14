using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.DAL.Models.Units;

namespace UnderSea.BLL.ViewModels
{
    public class OutgoingAttackViewModel
    {
        public string CountryName { get; set; }
        public IEnumerable<SimpleUnitViewModel> Units { get; set; }
    }
}
