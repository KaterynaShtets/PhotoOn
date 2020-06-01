using PhotOn.Web.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Account
{
    public class SignUpViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is missing or invalid.")]
        public string Email { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.Password, ErrorMessage = "Incorrect or missing password.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }

}
