using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.DTO;

namespace UnderSea.BLL.ViewModels
{
    public class MainPageViewModel
    {
        public StatusBarViewModel StatusBar { get; set; }
        public string CountryName { get; set; }
        public StructuresViewModel Structures { get; set; }
    }
}
