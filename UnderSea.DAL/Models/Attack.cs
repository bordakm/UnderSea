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
        [ForeignKey("Game")]
        public int? GameId { get; set; }
        public virtual User AttackerUser { get; set; }
        public virtual User DefenderUser { get; set; }
        public virtual List<Unit> UnitList { get; set; }
    }
}
