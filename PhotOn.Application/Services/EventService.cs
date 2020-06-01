using Microsoft.Extensions.Logging;
using PhotOn.Application.Dtos;
using PhotOn.Application.Interfaces;
using PhotOn.Application.Mapper;
using PhotOn.Core.Entities;
using PhotOn.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _db;
        private readonly ILogger<EventService> _logger;

        public EventService(IUnitOfWork unitOfWork, ILogger<EventService> logger)
        {
            _db = unitOfWork;
            _logger = logger;
        }

        public void AddEvent(EventDto eventDto)
        {
            try
            {
                var eventEntity = ObjectMapper.Mapper.Map<Event>(eventDto);
                _db.Events.Add(eventEntity);
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("AddEquipment failed");
            }
        }

        public void EditEvent(EventDto eventDto)
        {
            try
            {
                var eventEntity = ObjectMapper.Mapper.Map<Event>(eventDto);
                _db.Events.Update(eventEntity);
                _db.Save();
            }
            catch
            {
                _logger.LogWarning("EditEquipment failed");
            }
        }

        public IEnumerable<EventDto> GetAllEvents()
        {
            var events = _db.Equipments.GetAll();
                return ObjectMapper.Mapper.Map<IEnumerable<EventDto>>(events);
        }

        public EventDto GetEvent(int id)
        {
            var eventEntity = _db.Equipments.Get(id);
                return ObjectMapper.Mapper.Map<EventDto>(eventEntity);
        }

        public void SoftDeleteEvent(int id)
        {
            _db.Events.SoftDelete(id);
        }
    }
}
