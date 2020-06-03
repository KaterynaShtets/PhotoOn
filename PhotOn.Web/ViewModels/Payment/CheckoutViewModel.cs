using PhotOn.Web.Models.Payment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Payment
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "This field cannot be empty")]
        [Range(1.0, 100000)]
        public int Sum { get; set; }

        public LiqPayCheckoutFormModel LiqPayCheckoutFormModel { get; set; }
    }
}
