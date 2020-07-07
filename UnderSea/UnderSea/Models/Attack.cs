using System;
using System.Collections.Generic;
using System.Text;
using UnderSeaModel.Model;

namespace UnderSeaModel.Models
{
    public class Attack
    {

        public User AttackerUser { get; set; }
        public User DefenderUser { get; set; }
        public UnitGroup UnitGroup { get; set; }
    }
}
