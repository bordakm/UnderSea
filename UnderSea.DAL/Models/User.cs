using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string UserName { get; set; }
        public int Place { get; set; }
        public int Score { get; set; }
    }
}
