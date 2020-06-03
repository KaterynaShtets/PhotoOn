using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Models.Payment
{
    public class LiqPayCheckoutFormModel
    {
        public string Data { get; set; }
        public string Signature { get; set; }
    }
}
