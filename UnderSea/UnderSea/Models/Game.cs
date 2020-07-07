using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnderSeaModel.Models;

namespace UnderSeaModel.Model
{
    public class Game
    {
        public List<User> Users { get; set; }
        public List<Attack> Attacks { get; set; }
    }
}
