using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using UnderSea.DAL.Models.Units;

namespace UnderSea.DAL.Models
{
    public class Attack
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int AttackerUserId { get; set; }

        [ForeignKey("User")]
        public int DefenderUserId { get; set; }

        public User AttackerUser { get; set; }

        public User DefenderUser { get; set; }

        public List<Unit> UnitList { get; set; }
    }
}
