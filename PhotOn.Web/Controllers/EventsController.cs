using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhotOn.Application.Interfaces;

namespace PhotOn.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public IActionResult EventsList()
        {
            var events = _eventService.GetAllEvents();
            return View("EventsList", events);
        }
    }
}