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
    public class ApiPublicationsController : Controller
    {

        private readonly ILogger<ApiPublicationsController> _logger;
        private readonly IPublicationService _pServ;
        public ApiPublicationsController(ILogger<ApiPublicationsController> logger, IPublicationService pServ)
        {
            _logger = logger;
            _pServ = pServ;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PublicationDetailsDto>> GetAll()
        {
            return Json(_pServ.GetAllPublications());
        }

        [HttpGet("{Id:int}")]
        public ActionResult<IEnumerable<PublicationDetailsDto>> Get(int id)
        {
            var pubModel = _pServ.Get(id);
            if (pubModel == null) 
            {
                return NotFound();
            }
            return Json(pubModel);
        }

        [HttpPost]
        public ActionResult Post([FromForm] PublicationCreationDto publCreation)
        {

            _pServ.Add(publCreation);
            return Ok();
        }

        [HttpPut("{Id:int}")]
        public ActionResult Put(int id, [FromForm] PublicationCreationDto publicationModel)
        {
            _pServ.Edit(id, publicationModel);
            return NoContent();
        }

        [HttpDelete("{Id:int}")]
        public ActionResult Delete(int id) 
        {
            var exists = _pServ.Get(id);
            if (exists == null) 
            {
                return NotFound();
            }
            _pServ.Delete(id);
            return NoContent();
        }

        [HttpGet("filter")]
        public ActionResult<IEnumerable<PublicationDetailsDto>> Filter([FromQuery] PublicationFilterModel filterPublicationModel)
        {
            var publicationsQueryable = _pServ.FilterPublications(filterPublicationModel);

            HttpContext.InsertPaginationParametersInRepsonse(
                publicationsQueryable, filterPublicationModel.RecordsPerPage);

            var publications = publicationsQueryable.Paginate(filterPublicationModel.Pagination).ToList();

            return publications;
        }
        
        [HttpGet("profile")]
        public ActionResult<ProfileUserPageModel> SetProfile()
        {
            var likedPublications = _pServ.GetUserLikedPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var savedPublications = _pServ.GetUserSavedPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userPublications = _pServ.GetUserPublications(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var profileSetting = new ProfileUserPageModel()
            {
                LikedPublications = likedPublications,
                SavedPublications = savedPublications,
                PersonalPublications = userPublications
            };

            return profileSetting;
        }
    }
}
