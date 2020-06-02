using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Web.Mapper;
using PhotOn.Web.ViewModels;
using PhotOn.Web.ViewModels.Publications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotOn.Web.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IUserService _userService;
        private readonly IUtilService _utilService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IUserService userService, IMapper mapper)
        {
            _publicationService = publicationService;
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var publicationsViewModel = new PublicationsViewModel();

            var publicationDetailsDtos = _publicationService.GetAllPublications();
            var publications =
                _mapper.Map<IEnumerable<PublicationViewModel>>(publicationDetailsDtos);
            publicationsViewModel.Publications = publications;

            return View("Search", publications);
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
            return View("PublicationForm", publicationViewModel);
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
                WebMapper.Mapper.Map<PublicationCreationDto>(publicationViewModel);

            publicationModelForCreation.ImageFile = file;

            if (!ModelState.IsValid)
            {
                publicationViewModel = new PublicationViewModel();

                return View("PublicationForm", publicationViewModel);
            }
            if (publicationModelForCreation.Id == 0)
            {
                _publicationService.Add(publicationModelForCreation);
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