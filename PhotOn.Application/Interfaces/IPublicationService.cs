using PhotOn.Application.Dtos;
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
        PublicationDetailsDto Get(int id);
        IEnumerable<PublicationDetailsDto> GetAllPublications();
        IEnumerable<PublicationDetailsDto> FilterPublications(PublicationFilterModel filterPublicationModel);

        void Add(PublicationCreationDto carDto);
        void Edit(int id, PublicationCreationDto carDto);
        void Delete(int id);

        void LikePublication(int id);
        void SavePublication(int id);

        void BuyPublication(ApplicationUser user, PublicationDetailsDto publication);

        IEnumerable<PublicationDetailsDto> GetUserLikedPublications(string userId);
        IEnumerable<PublicationDetailsDto> GetUserSavedPublications(string userId);
        IEnumerable<PublicationDetailsDto> GetUserPublications(string userId);
        IEnumerable<PublicationDetailsDto> GetUserPurchasedPublications(string userId);
    }
}
