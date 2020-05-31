using Microsoft.AspNetCore.Identity;
using PhotOn.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            UserEvents = new List<UserEvent>();
            PublicationPurchases = new List<PublicationPurchase>();
            SavedPublications = new List<SavedPublication>();
            Publications = new List<Publication>();
            Likes = new List<Like>();
            Balance = 0;
        }

        public DateTime DOB { get; set; }
        public int Balance { get; set; }
        public ICollection<UserEvent> UserEvents { get; set; }
        public ICollection<PublicationPurchase> PublicationPurchases { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<SavedPublication> SavedPublications { get; set; }
        public ICollection<Publication> Publications { get; set; }
    }
}
