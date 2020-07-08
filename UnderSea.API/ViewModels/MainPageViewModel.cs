using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.API.DTO;

namespace UnderSea.API.ViewModels
{
    public class MainPageViewModel
    {
        public StatusBarViewModel StatusBar { get; set; }
        public string CountryName { get; set; }
        public StructuresViewModel Structures { get; set; }
    }
}
