using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UnderSea.DAL.Models.Upgrades
{ 
    public class Upgrade
    {
        public int Id { get; set; }        
        public UpgradeType Type { get; set; }
        public UpgradeState State { get; set; } = UpgradeState.Unresearched;
    }
}
