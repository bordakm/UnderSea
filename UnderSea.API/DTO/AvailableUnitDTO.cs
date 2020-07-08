using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API.DTO
{
    public class AvailableUnitDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableCount { get; set; }
    }
}
