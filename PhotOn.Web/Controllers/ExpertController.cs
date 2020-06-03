using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;
using PhotOn.Web.Service;
using PhotOn.Web.ViewModels.Publications;

namespace PhotOn.Web.Controllers
{
    public class ExpertController : Controller
    {
        private readonly IPublicationService _publicationService;
        private readonly IExpertService _expertService;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly IUserService _userService;

        public ExpertController(
            IPublicationService publicationService,
            IUserService userService,
        IExpertService expertService,
            IEmailSender emailSender,
            IMapper mapper)
        {
            _publicationService = publicationService;
            _expertService = expertService;
            _mapper = mapper;
            _emailSender = emailSender;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var publicationsViewModel = new PublicationsViewModel();

            var publicationDetailsDtos =
                _publicationService.GetAllPublications();

            var publications =
                _mapper.Map<IEnumerable<PublicationViewModel>>(publicationDetailsDtos);

            publicationsViewModel.Publications = publications;

            return View("ExpertList", publicationsViewModel);
        }

        public IActionResult Accept(int publicationId)
        {
            _expertService.ApprovePublication(publicationId);

            return RedirectToAction("Index", "Expert");
        }

        public async Task<IActionResult> Reject(int publicationId)
        {
            _expertService.RejectPublication(publicationId);

            await _emailSender.SendEmailAsync("kateryna.tkachenko@nure.ua", "katetkacenko@gmail.com", "Confirm your email address", "Your pub was rejected");
            return RedirectToAction("Index", "Expert");
        }
    }
}