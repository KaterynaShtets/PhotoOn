using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            UserEvents = new List<UserEvent>();
            PublicationPurchases = new List<PublicationPurchase>();
            SavedPublications = new List<SavedPublication>();
            Publications = new List<Publication>();
            Likes = new List<Like>();
        }

        public DateTime Year { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
        public ICollection<PublicationPurchase> PublicationPurchases { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<SavedPublication> SavedPublications { get; set; }
        public ICollection<Publication> Publications { get; set; }

    }
}
