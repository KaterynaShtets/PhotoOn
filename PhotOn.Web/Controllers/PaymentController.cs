using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;
using PhotOn.Web.Models.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotOn.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public PaymentController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        /// <summary>
        /// На цю сторінку LiqPay відправляє результат оплати. Вона вказана в data.result_url
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Redirect()
        {
            // --- Перетворюю відповідь LiqPay в Dictionary<string, string> для зручності:
            var request_dictionary = Request.Form.Keys.ToDictionary(key => key, key => Request.Form[key]);

            // --- Розшифровую параметр data відповіді LiqPay та перетворюю в Dictionary<string, string> для зручності:
            byte[] request_data = Convert.FromBase64String(request_dictionary["data"]);
            string decodedString = Encoding.UTF8.GetString(request_data);
            var request_data_dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedString);

            // --- Отримую сигнатуру для перевірки
            var mySignature = LiqPayHelper.GetLiqPaySignature(request_dictionary["data"]);

            // --- Якщо сигнатура серевера не співпадає з сигнатурою відповіді LiqPay - щось пішло не так
            if (mySignature != request_dictionary["signature"])
                return View("~/Views/Shared/_Error.cshtml");

            // --- Якщо статус відповіді "Тест" або "Успіх" - все добре
            if (request_data_dictionary["status"] == "sandbox" || request_data_dictionary["status"] == "success")
            {
                // Тут можна оновити статус замовлення та зробити всі необхідні речі. Id замовлення можна взяти тут: request_data_dictionary[order_id]

                var userId = request_data_dictionary["info"];

                var user = _userManager.Users
                    .SingleOrDefault(u => u.Id == userId);

                var amountString = request_data_dictionary["amount"];
                amountString = amountString.Substring(0, amountString.IndexOf("."));

                var amount = Convert.ToInt32(amountString);

                user.Balance += amount;

                var result = _userManager.UpdateAsync(user).Result;

                return View("~/Views/Shared/ReplenishmentSucceeded.cshtml");
            }

            return RedirectToAction("ReplenishBalance", "User");
        }
    }
}