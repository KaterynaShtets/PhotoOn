using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Model;

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

            var profileSetting = new ProfileUserPageModel()
            {
                LikedPublications = likedPublications,
                SavedPublications = savedPublications,
                PersonalPublications = userPurchasedPublications
            };

            return profileSetting;
        }
    }
}