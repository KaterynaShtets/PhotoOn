using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Validation
{
    public class UserDateOfBirth : ValidationAttribute
    {
        public string GetErrorMessage() =>
            $"Only users who are older 7 years old can register on PhotOn WebSite";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);

            var today = DateTime.Today;
            var age = today.Year - dateTime.Year;

            if (age > 7) 
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(GetErrorMessage());
        }
    }
}
