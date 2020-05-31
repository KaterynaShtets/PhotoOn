using PhotOn.Application.Dtos;
using PhotOn.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Model
{
    public class ProfileUserPageModel
    {
        public IEnumerable<PublicationDetailsDto> LikedPublications;
        public IEnumerable<PublicationDetailsDto> SavedPublications;
        public IEnumerable<PublicationDetailsDto> PersonalPublications;
    }
}
