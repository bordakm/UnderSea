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
    }
}
