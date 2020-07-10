using System;
using System.Collections.Generic;
using System.Text;
using UnderSea.DAL.Models.Units;

namespace UnderSea.DAL.Models
{
    public class Attack
    {
        public int Id { get; set; }
        public User AttackerUser { get; set; }
        public User DefenderUser { get; set; }
        public List<Unit> UnitList { get; set; }
    }
}
