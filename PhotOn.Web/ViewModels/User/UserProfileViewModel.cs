using PhotOn.Web.ViewModels.Publications;
using System.Collections.Generic;

namespace PhotOn.Web.ViewModels.User
{
    public class UserProfileViewModel
    {
        public IEnumerable<PublicationViewModel> LikedPublications;
        public IEnumerable<PublicationViewModel> SavedPublications;
        public IEnumerable<PublicationViewModel> PersonalPublications;
    }
}
