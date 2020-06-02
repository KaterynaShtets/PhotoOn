using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Model;
using PhotOn.Application.Models;
using PhotOn.Web.Helpers;

namespace PhotOn.Web.Controllers.Api
{
    [ApiController]
    [Route("api/publications")]
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;
        private readonly IUtilService _utilService;
        public PublicationsController( IPublicationService publicationService, IUserService userService, IUtilService utilService )
        {
            _publicationService = publicationService;
            _userService = userService;
            _utilService = utilService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PublicationDetailsDto>> GetAll()
        {
            return Json(_publicationService.GetAllPublications());
        }

        [HttpGet("{Id:int}")]
        public ActionResult<IEnumerable<PublicationDetailsDto>> Get(int id)
        {
            var pubModel = _publicationService.Get(id);
            if (pubModel == null)
            {
                return NotFound();
            }
            return Json(pubModel);
        }

        [HttpPost]
        public ActionResult Post([FromForm] PublicationCreationDto publCreation)
        {

            _publicationService.Add(publCreation);
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public ActionResult Put(int id, [FromForm] PublicationCreationDto publicationModel)
        {
            _publicationService.Edit(id, publicationModel);
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult Delete(int id)
        {
            var exists = _publicationService.Get(id);
            if (exists == null)
            {
                return NotFound();
            }
            _publicationService.Delete(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<PublicationDetailsDto>> Filter([FromQuery] PublicationFilterModel filterPublicationModel)
        {
            var publicationsQueryable = _publicationService.FilterPublications(filterPublicationModel);

            HttpContext.InsertPaginationParametersInRepsonse(
                publicationsQueryable, filterPublicationModel.RecordsPerPage);

            var publications = publicationsQueryable.Paginate(filterPublicationModel.Pagination).ToList();

            return publications;
        }

        [HttpGet("profile")]
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

            return Json(profileSetting);
        }

        [HttpPost("save/{id:int}")]
        public ActionResult SavePublication([FromQuery]int id)
        {
            _publicationService.SavePublication(id);
            return NoContent();
        }

        [HttpPost("like/{id:int}")]
        public ActionResult LikePublication(int id)
        {
            _publicationService.LikePublication(id);
            return NoContent();
        }

        [HttpPost("buy/{id:int}")]
        public async Task<ActionResult> BuyPublication(int id) 
        {
            var publication = _publicationService.Get(id);
            var user = await _userService.GetCurrentUser();
            if (_userService.CheckUserBalance(user.Balance, publication.Price))
            {
                _publicationService.BuyPublication(user, publication);
                return Ok();
            }
            else 
            {
                return BadRequest("Not enough money on balance");
            }
        }
    }
}
