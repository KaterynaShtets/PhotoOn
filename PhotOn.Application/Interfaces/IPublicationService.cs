using PhotOn.Application.Models;
using PhotOn.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotOn.Application.Interfaces
{
    public interface IPublicationService
    {
        PublicationDetailsModel Get(int id);
        IEnumerable<PublicationDetailsModel> GetAllPublications();
        IEnumerable<PublicationDetailsModel> FilterPublications(PublicationFilterModel filterPublicationModel);

        void Add(PublicationModelForCreation carDto);
        void Edit(int id, PublicationModelForCreation carDto);
        void Delete(int id);

        IEnumerable<PublicationDetailsModel> GetUserLikedPublications(string userId);
        IEnumerable<PublicationDetailsModel> GetUserSavedPublications(string userId);
        IEnumerable<PublicationDetailsModel> GetUserPublications(string userId);
    }
}
