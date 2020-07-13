using System.ComponentModel.DataAnnotations.Schema;

namespace UnderSea.DAL.Models.Units
{
    public class Unit
    {
        public int Id { get; set; }

        [ForeignKey("Attack")]
        public int? AttackId { get; set; }

        [ForeignKey("UnitGroup")]
        public int UnitGroupId { get; set; }

        public int Count { get; set; }

        [ForeignKey("UnitType")]
        public int TypeId { get; set; }

        public UnitType Type { get; set; }

        public int CalculateScore()
        {
            return Type.Score * Count;
        }
    }
}
