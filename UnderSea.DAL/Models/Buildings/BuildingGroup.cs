using System.Collections.Generic;

namespace UnderSea.DAL.Models.Buildings
{
    public class BuildingGroup
    {
        public int Id { get; set; }
        public virtual List<Building> Buildings { get; set; }
    }
}
