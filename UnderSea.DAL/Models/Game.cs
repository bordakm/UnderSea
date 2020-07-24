using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public virtual List<Attack> Attacks { get; set; }
        public int Round { get; set; }
        public string CoralPictureUrl { get; set; }
        public string PearlPictureUrl { get; set; }
        public string StonePictureUrl { get; set; }

        public Game()
        {
            CoralPictureUrl = "/images/coral.png";
            PearlPictureUrl = "/images/shell.png";
            StonePictureUrl = "/images/stone.png";
        }

        public void CalculateAttacks()
        {
            Random rand = new Random();

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
                attackerScore *= 1.00 + attackerScoreModifier / 100.00;

                //calculating random for attacker                
                attackerScore *= 1 + (new Random().NextDouble() * 10 - 5) / 100;

                //if the defender wins
                if (defenderScore > attackerScore)
                {
                    //levonjuk az egységeket az attacking armyból
                    /*for (int i = attUserCountry.AttackingArmy.Units.Count(); i > 0; i--)
                    {
                        foreach (var unit in attack.UnitList)
                        {
                            if (attUserCountry.AttackingArmy.Units[i].Type.Id == unit.Type.Id
                                && attUserCountry.AttackingArmy.Units[i].BattlesSurvived == unit.BattlesSurvived)
                            {
                                attUserCountry.AttackingArmy.Units.RemoveAt(i);
                            }

                        }
                    }*/


                    // csökkentjük a támadó armyját 10%-kal
                    var unitCount = attack.UnitList.Count;
                    int newCount = Convert.ToInt32(Math.Ceiling(unitCount * 0.9));
                    for (int i = 0; i < unitCount - newCount; i++)
                    {
                        var unitToDelete = attack.UnitList[rand.Next(0, attack.UnitList.Count)];
                        attUserCountry.AttackingArmy.Units.Remove(unitToDelete);
                        attack.UnitList.Remove(unitToDelete);
                        //attUserCountry.AttackingArmy.Units.RemoveAt(rand.Next(0, unitCount - i));
                    }


                    foreach (var unit in attack.UnitList)
                    {
                        attUserCountry.AttackingArmy.Units.Where((u => u.Id == unit.Id)).ToList().ForEach(u =>
                        {
                            u.UnitGroupId = attUserCountry.DefendingArmyId;
                            u.BattlesSurvived++;
                        });
                        attUserCountry.AttackingArmy.Units.RemoveAll((u => u.Id == unit.Id));
                    }



                    //hozzáadjuk a maradék egységeket attacker defender armyjához
                    attUserCountry.DefendingArmy.Units.AddRange(attack.UnitList);

                    //adding +1 battle in defCountry
                    foreach (var unit in defUserCountry.DefendingArmy.Units)
                    {
                        unit.BattlesSurvived++;
                    }
                }

                //if the attacker wins
                else if (attackerScore > defenderScore)
                {
                    foreach (var unit in attack.UnitList)
                    {
                        attUserCountry.AttackingArmy.Units.Where((u => u.Id == unit.Id)).ToList().ForEach(u =>
                        {
                            u.UnitGroupId = attUserCountry.DefendingArmyId;
                            u.BattlesSurvived++;
                        });
                        attUserCountry.AttackingArmy.Units.RemoveAll((u => u.Id == unit.Id));
                    }
                    //hozzáadjuk az attacker defender armyjához
                    attUserCountry.DefendingArmy.Units.AddRange(attack.UnitList);


                    //csökkentjük a deffender armyját 10%al
                    var unitCount = defUserCountry.DefendingArmy.Units.Count;
                    int newCount = Convert.ToInt32(Math.Ceiling(unitCount * 0.9));
                    for (int i = 0; i < unitCount - newCount; i++)
                    {
                        defUserCountry.DefendingArmy.Units.RemoveAt(rand.Next(0, unitCount - i));
                    }

                    //adding +1 battle in attCountry
                    foreach (var unit in defUserCountry.DefendingArmy.Units)
                    {
                        unit.BattlesSurvived++;
                    }

                    //nyereség jóváírása
                    attUserCountry.Pearl += Convert.ToInt32(Math.Ceiling(defUserCountry.Pearl * 0.5));
                    defUserCountry.Pearl -= Convert.ToInt32(Math.Ceiling(defUserCountry.Pearl * 0.5));

                    attUserCountry.Coral += Convert.ToInt32(Math.Ceiling(defUserCountry.Coral * 0.5));
                    defUserCountry.Coral -= Convert.ToInt32(Math.Ceiling(defUserCountry.Coral * 0.5));
                }
            }
        }
    }
}