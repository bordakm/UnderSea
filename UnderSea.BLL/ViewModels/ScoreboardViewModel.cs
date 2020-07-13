using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.ViewModels
{
    public class ScoreboardViewModel
    {
        public int Id { get; set; }
        public int Place { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}
