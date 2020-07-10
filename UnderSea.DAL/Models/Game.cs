using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models
{
    public class Game
    {
        public int Id { get; set; }
        public List<User> Users { get; set; }
        public List<Attack> Attacks { get; set; }
        public int Round { get; set; }
        public string CoralPictureUrl { get; set; }
        public string PearlPictureUrl { get; set; }

        public void CalculateAttacks()
        {
            //kik a defenderek?
            //sikeres a támadás ha a támadók támadó ereje nagyobb mint a védekezők védekező ereje 
            //támadók ereje random változik +-5%
            //vesztes sereg 10%a megsemmisül
            //ha a támadó nyer akkor a vesztestől elviszi a gyöngy és a korall felét
        }
    }
}
