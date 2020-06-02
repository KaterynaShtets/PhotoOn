using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Web.Mapper;
using PhotOn.Web.ViewModels;
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

            return View("UNSORTED/Main");
        }

        public ActionResult New()
        {
            var publicationViewModel = new PublicationViewModel();

            // нужно сделать эквипмент сервис и репозиторий
            //publicationDetailsModel.EquipmentModels = 
            //                        equipmentService.GetAll();

            // нужно сделать эквипмент сервис и репозиторий
            //publicationDetailsModel.TagModels =
            //                        tagService.GetAll();

            return View("PublicationForm", publicationViewModel);
        }

        public ActionResult Details(int publicationId)
        {
            var publicationDetailsModel = _publicationService.Get(publicationId);

            var publicationViewModel =
                WebMapper.Mapper.Map<PublicationViewModel>(publicationDetailsModel);

            return View("PublicationDetails", publicationViewModel);
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

        public async Task<ActionResult> BuyPublication(int id)
        {
            var publication = _publicationService.Get(id);
            var user = await _userService.GetCurrentUser();
            if (_utilService.CheckBalance(user.Balance, publication.Price))
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