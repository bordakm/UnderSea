using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnderSea.DAL.Models.Buildings
{
    public class BuildingGroup
    {
        public int Id { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public List<Building> Buildings { get; set; }
    }
}
