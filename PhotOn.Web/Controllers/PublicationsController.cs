using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Web.Mapper;
using PhotOn.Web.Models;
using PhotOn.Web.ViewModels;
using System.Collections.Generic;

namespace PhotOn.Web.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IMapper _mapper;

        public PublicationsController(IPublicationService publicationService, IMapper mapper)
        {
            _publicationService = publicationService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var publicationsViewModel = new PublicationsViewModel();

            var publicationDetailsDtos = _publicationService.GetAllPublications();
            var publications =
                _mapper.Map<IEnumerable<PublicationViewModel>>(publicationDetailsDtos);
            publicationsViewModel.Publications = publications;

            return View("PublicationList", publicationsViewModel);
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
    }
}