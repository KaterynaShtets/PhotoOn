using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;

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
            
        
        public ActionResult Publications()
        {
            var publicationModels = _publicationService.GetAllPublications();

            return View("Publications", publicationModels);
        }
    }
}
