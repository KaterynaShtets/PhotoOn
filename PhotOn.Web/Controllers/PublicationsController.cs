using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Web.Mapper;
using PhotOn.Web.Models;
using PhotOn.Web.ViewModels;
using PhotOn.Web.ViewModels.Publications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;
        private readonly IUtilService _utilService;
        private readonly IMapper _mapper;
        private readonly IEquipmentService _equipmentService;
        private readonly ITagService _tagService;

        public PublicationsController(IPublicationService publicationService, IEquipmentService equipmentService,
            IUserService userService, ITagService tagService, IMapper mapper)
        {
            _publicationService = publicationService;
            _userService = userService;
            _mapper = mapper;
            _equipmentService = equipmentService;
            _tagService = tagService;
        }


        public ActionResult Index(string sortOrder = null, string searchString = null, int filterTag = -1, bool mapWasDisplayed = false)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["LikeSortParm"] = sortOrder == "Like" ? "like_desc" : "Like";
            ViewData["currentFilter"] = searchString;
            ViewData["displayMap"] = mapWasDisplayed;

            var publicationsViewModel = new PublicationsViewModel();

            var publicationDetailsDtos = _publicationService.GetAllPublications().AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                publicationDetailsDtos = publicationDetailsDtos.Where(s => s.Title.ToLower().Contains(searchString.ToLower())
                                       || s.TagModels.Any(t => t.Title.Contains(searchString)));
            }

            if (filterTag != -1)
            {
                publicationDetailsDtos = publicationDetailsDtos.Where(s => s.TagModels.Any(t => t.Id == filterTag));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    publicationDetailsDtos = publicationDetailsDtos.OrderByDescending(s => s.Title);
                    break;
                case "Price":
                    publicationDetailsDtos = publicationDetailsDtos.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    publicationDetailsDtos = publicationDetailsDtos.OrderByDescending(s => s.Price);
                    break;
                case "Like":
                    publicationDetailsDtos = publicationDetailsDtos.OrderBy(s => s.LikeCount);
                    break;
                case "like_desc":
                    publicationDetailsDtos = publicationDetailsDtos.OrderByDescending(s => s.LikeCount);
                    break;
                default:
                    publicationDetailsDtos = publicationDetailsDtos.OrderBy(s => s.Title);
                    break;
            }

            var publications =
                _mapper.Map<IEnumerable<PublicationViewModel>>(publicationDetailsDtos.ToList());
            publicationsViewModel.Publications = publications;

            return View("Search", publications);
        }

        public ActionResult PublicationsManagement()
        {
            var publicationsViewModel = new PublicationsViewModel();

            var publicationDetailsDtos =
                _publicationService.GetAllPublications();

            var publications =
                _mapper.Map<IEnumerable<PublicationViewModel>>(publicationDetailsDtos);

            publicationsViewModel.Publications = publications;

            return View("PublicationList", publicationsViewModel);
        }

        public ActionResult ViewMore(int Id) 
        {
            if (_publicationService.isPurchased(Id))
            {
                return RedirectToAction("Details", "Publications", new { publicationId = Id});
            }
            else 
            {
                return RedirectToAction("MakePurchase", "User");
            }
        }

        [HttpGet]
        public ActionResult NewPublication()
        {
            var publicationViewModel = new PublicationViewModel();

            return View("PublicationForm", publicationViewModel);
        }


        [HttpPost]
        public ActionResult NewPublication(PublicationViewModel publicationViewModel)
        {
            var publicationDto = _mapper.Map<PublicationCreationDto>(publicationViewModel);
            _publicationService.Add(publicationDto);
            return RedirectToAction("");
        }

        public ActionResult Details(int publicationId)
        {
            var publicationDetailsModel = _publicationService.Get(publicationId);

            var publicationViewModel =
                WebMapper.Mapper.Map<PublicationViewModel>(publicationDetailsModel);

            return View("PublicationDetail", publicationViewModel);
        }

        public ActionResult Edit(int publicationId)
        {
            var publicationDetailsModel = _publicationService.Get(publicationId);

            var publicationViewModel =
                WebMapper.Mapper.Map<PublicationViewModel>(publicationDetailsModel);

            return View("PublicationForm", publicationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PublicationViewModel publicationViewModel)
        {
            IFormFile file = publicationViewModel.Picture;
            
            var publicationModelForCreation =
                _mapper.Map<PublicationCreationDto>(publicationViewModel);
            publicationModelForCreation.ImageFile = file;
            publicationModelForCreation.TagsDtos = publicationViewModel.TagModels;
            publicationModelForCreation.EquipmentDtos = publicationViewModel.EquipmentModels;
            
            if (!ModelState.IsValid)
            {
                publicationViewModel = new PublicationViewModel();

                return View("PublicationForm", publicationViewModel);
            }
            if (publicationModelForCreation.Id == 0)
            {
                try
                {
                    _publicationService.Add(publicationModelForCreation);
                }
                catch
                {
                    return View("PublicationForm", publicationViewModel);
                }
            }
            else
            {
                _publicationService
                    .Edit(publicationModelForCreation.Id, publicationModelForCreation);
            }
            return RedirectToAction("Index", "Publications");
        }

        public ActionResult Delete(int publicationId)
        {
            _publicationService.Delete(publicationId);

            return RedirectToAction("Index", "Publications");
        }

        public ActionResult SetLike(int publicationId )
        {
            _publicationService.LikePublication(publicationId);
            return RedirectToAction("Index", "Publications");
        }

        public ActionResult SetSave(int publicationId)
        {
            var userId = _userService.GetCurrentUserId();
            _publicationService.SavePublication(userId, publicationId);
            return RedirectToAction("Index", "Publications");
        }
    }
}