using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Model;
using PhotOn.Web.Mapper;
using PhotOn.Web.Models.Payment;
using PhotOn.Web.ViewModels;
using PhotOn.Web.ViewModels.Payment;
using PhotOn.Web.ViewModels.Publications;
using PhotOn.Web.ViewModels.User;
using PhotOn.Web.ViewModels.Util;

namespace PhotOn.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            IPublicationService publicationService,
            IUserService userService,
            IMapper mapper)
        {
            _publicationService = publicationService;
            _userService = userService;
        }

        public ActionResult<ProfileUserPageModel> SetProfile()
        {
            var userId = _userService.GetCurrentUserId();

            var likedPublications = _publicationService.GetUserLikedPublications(userId);
            var savedPublications = _publicationService.GetUserSavedPublications(userId);
            var userPurchasedPublications = _publicationService.GetUserPurchasedPublications(userId);

            var likedPublicationViewModels =
              _mapper.Map<IEnumerable<PublicationViewModel>>(likedPublications);
            var savedPublicationsViewModels =
              _mapper.Map<IEnumerable<PublicationViewModel>>(savedPublications);
            var purchasedPublicationsViewModels =
              _mapper.Map<IEnumerable<PublicationViewModel>>(userPurchasedPublications);

            var profileSetting = new UserProfileViewModel()
            {
                LikedPublications = likedPublicationViewModels,
                SavedPublications = savedPublicationsViewModels,
                PersonalPublications = purchasedPublicationsViewModels
            };

            return View("Profile",profileSetting);
        }

        public ActionResult ReplenishBalance() 
        {
            var usersBalance =
             _userService.GetCurrentUser().Result.Balance;
            var replenishBalanceViewModel =
              new ReplenishBalanceViewModel(usersBalance);

            return View("Balance", replenishBalanceViewModel);
        }

        public async Task<ActionResult> ConfirmPayment( int publicationId)
        {
            var publication = _publicationService.Get(publicationId);
            var user = await _userService.GetCurrentUser();

            var paymentModel = new PaymentViewModel()
            {
                PublicationPrice = publication.Price,
                UserBalance = user.Balance,
                PublicationId = publicationId
            };
            
           return View("Payment", paymentModel);
        }

        public async Task<ActionResult> MakePurchase(int publicationId)
        {
            var publication = _publicationService.Get(publicationId);
            var user = await _userService.GetCurrentUser();

            if (!_userService.AgeIsOkay(user.DOB))
            {
                var message = new MessageViewModel
                {
                    Message = "Soory, only users older than 16 years old can make purchases"
                };

                return View("~/Views/Shared/ErrorMessage.cshtml", message);
            }

            if (!_userService.UserBalanceIsOkay(user.Balance, publication.Price))
            {
                var message = new MessageViewModel
                {
                    Message = "Soory, you don't hane anough mony to proceed purchase"
                };

                return View("~/Views/Shared/ErrorMessage.cshtml", message);
            }
            _publicationService.BuyPublication(user, publication);

            return RedirectToAction("Index", "Publications");
        }

        public ActionResult GetCheckout(int sum)
        {
            var uniqe_guid = Guid.NewGuid();

            var userId = _userService.GetCurrentUserId();

            LiqPayCheckoutFormModel liqPayCheckoutFormModel =
                LiqPayHelper.GetLiqPayModel(uniqe_guid.ToString(), "Balance Replenishment", sum, userId);

            CheckoutViewModel checkoutViewModel = new CheckoutViewModel
            {
                Sum = sum,
                LiqPayCheckoutFormModel = liqPayCheckoutFormModel
            };

            return View("Check", checkoutViewModel);
        }
    }
}