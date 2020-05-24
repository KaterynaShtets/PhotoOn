using PhotOn.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IPublicationService
    {
        PublicationDto Get(int id);
        IEnumerable<PublicationDto> GetAllPublications();
        void Add(PublicationDto publicationDto);
        void Edit(PublicationDto publicationDto);
        void MarkAsDeleted(int id);
        void MarkAsNotDeleted(int id);
        void MarkAsNotAvailable(int id);
        int GetId(PublicationDto publicationDto);
    }
}
