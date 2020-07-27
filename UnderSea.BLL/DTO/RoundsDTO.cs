using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UnderSea.BLL.Services;

namespace UnderSea.BLL.DTO
{
    public class RoundsDTO
    {
        [CustomValidation(typeof(ValidationService), nameof(ValidationService.ValidateNegative))]
        public int Number { get; set; }
    }
}
