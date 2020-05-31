using PhotOn.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Model
{
    public class ProfileUserPageModel
    {
        public IEnumerable<PublicationDetailsModel> LikedPublications;
        public IEnumerable<PublicationDetailsModel> SavedPublications;
        public IEnumerable<PublicationDetailsModel> PersonalPublications;
    }
}
