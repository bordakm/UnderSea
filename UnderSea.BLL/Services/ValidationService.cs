using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UnderSea.BLL.Services
{
    public class ValidationService
    {
        public static ValidationResult ValidateNegative (int number)
        {
            return number >= 0 ? ValidationResult.Success : new ValidationResult("The value can't be negative");
        }
    }
}
