using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSeaModel.Model
{
    public class Country
    {
        public List<Building> Buildings { get; set; }
        public List<Unit> Army { get; set; }
    }
}
