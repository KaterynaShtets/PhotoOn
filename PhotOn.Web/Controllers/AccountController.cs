using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Core.Entities;
using PhotOn.Web.Service;
using PhotOn.Web.ViewModels.Account;

namespace PhotOn.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;
        public AccountController(IUserService userService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        public IActionResult SignUp()
        {
            var model = new SignUpViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = "User" };
                if ((await _userManager.FindByEmailAsync(model.Email)) == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        DOB = model.DOB
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    user = await _userManager.FindByEmailAsync(model.Email);
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "User");

                        var confirmationLink = Url.ActionLink("ConfirmEmail", "Account", new { userId = user.Id, @token = token });

                        await _emailSender.SendEmailAsync("kateryna.tkachenko@nure.ua", user.Email, "Confirm your email address", confirmationLink);
                        return View("ConfirmationEmail");
                    }

                    ModelState.AddModelError("SignUp", string.Join("", result.Errors.Select(x => x.Description)));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return RedirectToAction("SignIn");
            }
            return new NotFoundResult();
        }

        public IActionResult SignIn()
        {
            return View(new SignInViewModel());

        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, returnUrl);
            var callBackUrl = Url.Action("ExternalLoginCallBack");
            properties.RedirectUri = callBackUrl;
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallBack()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            var emailClaim = info.Principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
            var user = new ApplicationUser { Email = emailClaim.Value, UserName = emailClaim.Value };
            if ((await _userManager.FindByEmailAsync(emailClaim.Value)) == null)
            {
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddLoginAsync(user, info);
                }
                else
                {
                    return RedirectToAction("ExternalLogin", "Identity");
                }
            }
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Login", "Cannot login.");
                }
            }
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Signout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Signin");
        }
    }
}