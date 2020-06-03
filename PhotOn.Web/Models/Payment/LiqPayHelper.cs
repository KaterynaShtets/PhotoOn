using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PhotOn.Web.Models.Payment
{
    public class LiqPayHelper
    {
        static private readonly string _private_key;
        static private readonly string _public_key;

        static LiqPayHelper()
        {
            _public_key = "i84886278296";     // Public Key компанії, який можна знайти в особистому кабінеті на сайті liqpay.ua
            _private_key = "F3gkOzOLXDRnr5uUPGrELZbitkR1rpLl9Sv1vGEf";    // Private Key компанії, який можна знайти в особистому кабінеті на сайті liqpay.ua
        }

        static public LiqPayCheckoutFormModel GetLiqPayModel(
            string order_id,
            string description,
            int price,
            string userId)
        {
            var signature_source = new LiqPayCheckout()
            {
                public_key = _public_key,
                version = 3,
                action = "pay",
                amount = price,
                currency = "USD",
                description = description,
                order_id = order_id,
                sandbox = 1,

                result_url = "https://localhost:44308/Payment/Redirect",
                server_url = "https://localhost:44308/Payment/Redirect",

                info = userId,
            };
            var json_string = JsonConvert.SerializeObject(signature_source);
            var data_hash = Convert.ToBase64String(Encoding.UTF8.GetBytes(json_string));
            var signature_hash = GetLiqPaySignature(data_hash);

            var model = new LiqPayCheckoutFormModel();
            model.Data = data_hash;
            model.Signature = signature_hash;
            return model;
        }

        static public string GetLiqPaySignature(string data)
        {
            return Convert.ToBase64String(SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(_private_key + data + _private_key)));
        }
    }
}
