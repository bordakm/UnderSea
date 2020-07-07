using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSeaModel.Model
{
    public class User
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string UserName { get; set; }
    }
}
