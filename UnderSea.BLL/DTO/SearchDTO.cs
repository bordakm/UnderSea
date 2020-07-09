using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.BLL.DTO
{
    public class SearchDTO
    {
        public string SearchPhrase { get; set; }
        public int Page { get; set; }
        public int ItemPerPage { get; set; }
    }
}
