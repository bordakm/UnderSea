using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace UnderSea.DAL.Models.Units
{
    [Table("UnitType")]
    public abstract class UnitType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int PearlCostPerTurn { get; set; }
        public int CoralCostPerTurn { get; set; }
        public string ImageUrl { get; set; }
        public int Score { get; set; }
        public virtual List<UnitLevel> Levels { get; set; }
        public int GetLevel (int battlesSurvived)
        {
            var levels = Levels.OrderBy(level => level.BattlesNeeded)
                .Reverse();

            foreach (var level in levels)
            {
                if (level.BattlesNeeded <= battlesSurvived)
                {
                    return level.Level;
                }
            }
            return levels.Last().Level;
        }

        public double GetAttackScore(int battlesSurvived)
        {
            var levels = Levels.OrderBy(level => level.BattlesNeeded)
                .Reverse();
            foreach (var level in levels)
            {
                if (level.BattlesNeeded <= battlesSurvived)
                {
                    return level.AttackScore;
                }
            }
            return levels.Last().AttackScore;
        }

        public double GetDefenseScore(int battlesSurvived)
        {
            var levels = Levels.OrderBy(level => level.BattlesNeeded)
                .Reverse();
            foreach (var level in levels)
            {
                if (level.BattlesNeeded <= battlesSurvived)
                {
                    return level.DefenseScore;
                }
            }
            return levels.Last().DefenseScore;
        }
    }
}
