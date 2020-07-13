using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class UnitGroup
    {
        public UnitGroup()
        {
            Units = new List<Unit>();
        }

        public int Id { get; set; }

        public List<Unit> Units { get; set; }
    }
}
