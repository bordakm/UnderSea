using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class AvailableUnitViewModel
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
        public int AvailableCount { get; set; }
        public int AllCount { get; set; }
        public string ImageUrl { get; set; }
    }
}
