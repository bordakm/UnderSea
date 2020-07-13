using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class BuildingGroup
    {
        public int Id { get; set; }
        public List<Building> Buildings { get; set; } = new List<Building> { new Building{ Type = new FlowManager()} ,
                                                                             new Building{ Type = new ReefCastle()}};
    }
}
