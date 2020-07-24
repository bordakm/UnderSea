using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnderSea.DAL.Models.Units
{
    public class UnitLevel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UnitType")]
        public int UnitTypeId { get; set; }
        public int Level { get; set; }
        public int BattlesNeeded { get; set; }
        public double AttackScore { get; set; }
        public double DefenseScore { get; set; }
    }
}
