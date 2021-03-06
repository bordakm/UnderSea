﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnderSea.DAL.Models.Units
{
    public class CombatSeaHorse : UnitType
    {
        public CombatSeaHorse()
        {
            Name = "Csatacsikó";
            ImageUrl = "/images/units/seahorse.png";
            Price = 50;
            PearlCostPerTurn = 1;
            CoralCostPerTurn = 1;
            Score = 5;
        }
    }
}
