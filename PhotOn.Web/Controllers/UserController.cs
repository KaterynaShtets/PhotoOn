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
using PhotOn.Web.ViewModels;
using PhotOn.Web.ViewModels.Publications;
using PhotOn.Web.ViewModels.User;
using PhotOn.Web.ViewModels.Util;

namespace PhotOn.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;
        private readonly IUtilService _utilService;
        private readonly IMapper _mapper;

        public UserController(IPublicationService publicationService, IUserService userService, IMapper mapper)
        {
            _publicationService = publicationService;
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult<ProfileUserPageModel> SetProfile()
        {
            var likedPublications = _publicationService.GetUserLikedPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var savedPublications = _publicationService.GetUserSavedPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userPurchasedPublications = _publicationService.GetUserPurchasedPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));

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

            return View("Balance");
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

        public async Task<ActionResult> MakePayment(int publicationId)
        {
            var publication = _publicationService.Get(publicationId);
            var user = await _userService.GetCurrentUser();

            if (_userService.CheckUserAge(user.DOB))
            {
                var message = new MessageViewModel
                {
                    Message = "Soory, only users older than 16 years old can make purchases"
                };

                return RedirectToAction("ErrorMessage", new { model = message });
            }

            return RedirectToAction("Search", "Publications");
        }

        public ActionResult GetCheckout()
        {

            return View("Check");
        }
    }
}