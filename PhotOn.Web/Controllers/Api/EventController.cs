using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;

namespace PhotOn.Web.Controllers.Api
{
    [Route("api/events")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
     
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetAll() 
        {
            return Json(_eventService.GetAllEvents());
        }

        [HttpGet("{id:int}")]
        public ActionResult<IEnumerable<EventDto>> Get(int id)
        {
            var eventModel = _eventService.GetEvent(id);
            if (_eventService == null)
            {
                return NotFound();
            }
            return Json(eventModel);
        }
    }
}