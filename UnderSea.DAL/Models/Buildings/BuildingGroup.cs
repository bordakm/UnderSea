using System.Collections.Generic;

namespace UnderSea.DAL.Models.Buildings
{
    public class BuildingGroup
    {
        public int Id { get; set; }
        public List<Building> Buildings { get; set; }
    }
}
