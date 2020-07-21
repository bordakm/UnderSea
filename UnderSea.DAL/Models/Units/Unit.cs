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
        [ForeignKey("UnitType")]
        public int TypeId { get; set; }
        public UnitType Type { get; set; }
        public int BattlesSurvived { get; set; }
        public int Level => Type.GetLevel(BattlesSurvived);
        public double AttackScore => Type.GetAttackScore(BattlesSurvived);
        public double DefenseScore => Type.GetDefenseScore(BattlesSurvived);
        
    }
}
