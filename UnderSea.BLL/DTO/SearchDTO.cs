using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using UnderSea.BLL.Services;

namespace UnderSea.BLL.DTO
{
    public class SearchDTO
    {
        public string SearchPhrase { get; set; }

        [CustomValidation(typeof(ValidationService), nameof(ValidationService.ValidateNegative))]
        public int? Page { get; set; } = 1;
        [CustomValidation(typeof(ValidationService), nameof(ValidationService.ValidateNegative))]
        public int? ItemPerPage { get; set; } = 10;
    }
}
