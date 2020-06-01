using PhotOn.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IEventService
    {
        EventDto GetEvent(int id);
        IEnumerable<EventDto> GetAllEvents();
        void AddEvent(EventDto tagDto);
        void EditEvent(EventDto tagDto);
        void SoftDeleteEvent(int id);
    }
}
