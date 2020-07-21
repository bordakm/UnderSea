using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public IEnumerable<User> Users { get; set; }
        public List<Attack> Attacks { get; set; }
        public int Round { get; set; }
        public string CoralPictureUrl { get; set; }
        public string PearlPictureUrl { get; set; }

        public Game()
        {
            CoralPictureUrl = "majd/lesz/kep.jpeg";
            PearlPictureUrl = "majd/lesz/kep.jpeg";
        }

        public void CalculateAttacks()
        {
            foreach (var attack in Attacks)
            {
                double defenderScore = 0;
                double attackerScore = 0;

                double defenderScoreModifier = 0;
                double attackerScoreModifier = 0;

                var defUserCountry = attack.DefenderUser.Country;
                var attUserCountry = attack.AttackerUser.Country;

                //calculationg defender base score
                foreach (var unit in defUserCountry.DefendingArmy.Units)
                {
                    defenderScore += unit.DefenseScore;
                }

                //calculating defender modifier
                foreach (var upgrade in defUserCountry.Upgrades)
                {
                    if (upgrade.State == Upgrades.UpgradeState.Researched)
                        defenderScoreModifier += upgrade.Type.DefenseBonusPercentage;
                }
                defenderScore *= 1 + defenderScoreModifier / 100;

                //calculating attacker base score
                foreach (var unit in attack.UnitList)
                {
                    attackerScore += unit.AttackScore;
                }

                //calculating attacker modifier
                foreach (var upgrade in attUserCountry.Upgrades)
                {
                    if (upgrade.State == Upgrades.UpgradeState.Researched)
                        attackerScoreModifier += upgrade.Type.AttackBonusPercentage;
                }
                attackerScore *= 1 + attackerScoreModifier / 100;

                //calculating random for attacker
                Random rand = new Random();
                attackerScore *= 1 + rand.Next(-5, 5) / 100;

                //if the defender wins
                if (defenderScore > attackerScore)
                {
                    //CR Ready
                    //hozzáadjuk az attacker defender armyjához 10%osan csökkentve
                    var dummyList = attack.UnitList;

                    var unitCount = dummyList.Count;
                    int newCount = Convert.ToInt32(Math.Ceiling(unitCount * 0.9));
                    for (int i = 0; i < unitCount - newCount; i++)
                    {
                        dummyList.RemoveAt(rand.Next(0, unitCount - i));
                    }

                    attUserCountry.DefendingArmy.Units.AddRange(dummyList);


                    //levonjuk az egységeket az attacking armyból
                    foreach (var unit in attack.UnitList)
                    {
                        foreach (var attackingUnit in attUserCountry.AttackingArmy.Units)
                        {
                            if (unit.Type.Id == attackingUnit.Type.Id)
                                attackingUnit.Count -= unit.Count;
                        }
                    }

                }
                else if (attackerScore > defenderScore)
                {
                    //levonjuk az egységeket az attacking armyból
                    foreach (var unit in attack.UnitList)
                    {
                        foreach (var attackingUnit in attUserCountry.AttackingArmy.Units)
                        {
                            if (unit.Type.Id == attackingUnit.Type.Id)
                                attackingUnit.Count -= unit.Count;
                        }
                    }

                    //hozzáadjuk a defender armyhoz
                    foreach (var unit in attack.UnitList)
                    {
                        foreach (var defendingunit in attUserCountry.DefendingArmy.Units)
                        {
                            if (unit.Type.Id == defendingunit.Type.Id)
                                defendingunit.Count += unit.Count;
                        }
                    }

                    //CR Ready
                    //csökkentjük a deffender armyját 10%al
                    var unitCount = defUserCountry.DefendingArmy.Units.Count;
                    int newCount = Convert.ToInt32(Math.Ceiling(unitCount * 0.9));
                    for(int i = 0; i< unitCount - newCount; i++)
                    {
                        defUserCountry.DefendingArmy.Units.RemoveAt(rand.Next(0, unitCount-i));
                    }

                    //nyereség jóváírása
                    attUserCountry.Pearl += Convert.ToInt32(Math.Ceiling(defUserCountry.Pearl * 0.5));
                    defUserCountry.Pearl -= Convert.ToInt32(Math.Ceiling(defUserCountry.Pearl * 0.5));

                    attUserCountry.Coral += Convert.ToInt32(Math.Ceiling(defUserCountry.Coral * 0.5));
                    defUserCountry.Coral -= Convert.ToInt32(Math.Ceiling(defUserCountry.Coral * 0.5));
                }
            }

            Attacks.Clear();
        }
    }
}
