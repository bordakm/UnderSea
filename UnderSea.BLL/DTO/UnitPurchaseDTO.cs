using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.Services;

namespace UnderSea.BLL.DTO
{
    public class UnitPurchaseDTO
    {
        public int TypeId { get; set; }

        [CustomValidation(typeof(ValidationService), nameof(ValidationService.ValidateNegative))]
        public int Count { get; set; }
    }
}
