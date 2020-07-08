﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnderSea.API.DTO
{
    public class BuildingInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
    }
}
