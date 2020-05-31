using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotOn.Application.Validations
{
    public class FileSIzeValidation : ValidationAttribute
    {
        private readonly int maxFileSizeMbs;

        public FileSIzeValidation(int MaxFileSizeMbs)
        {
            maxFileSizeMbs = MaxFileSizeMbs;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            if (value == null) 
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;

            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (formFile.Length > maxFileSizeMbs * 1024 * 1024) 
            {
                return new ValidationResult($"File size cannot be bigger than {maxFileSizeMbs}");
            }

            return ValidationResult.Success;
        }
    }
}
