﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API.DTO
{
    public class ScoreboardDTO
    {
        public int Place { get; set; }
        public int UserId { get; set; }
        public int UserName { get; set; }
        public int Score { get; set; }
    }
}
