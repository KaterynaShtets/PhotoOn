using PhotOn.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public enum TimeOfTheYear
    {
        None,
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public class Publication : Entity
    {
        public Publication()
        {
            PublicationEquipments = new List<PublicationEquipment>();
            PublicationTags = new List<PublicationTag>();
            SavedPublications = new List<SavedPublication>();
            PublicationPurchases = new List<PublicationPurchase>();
            Likes = new List<Like>();
        }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Title { get; set; }
        public string ImageLink { get; set; }
        public int Price { get; set; }
        public decimal coordX { get; set; }
        public decimal coordY { get; set; }
        public DateTime PublicationDate { get; set; }
        public TimeOfTheYear Season { get; set; }
        public string TextDescription { get; set; }
        public int LikeCount { get;  set; }
        public bool IsApproved { get; set; }
        public ICollection<PublicationEquipment> PublicationEquipments { get; private set; }
        public ICollection<PublicationTag> PublicationTags { get; private set; }
        public ICollection<PublicationPurchase> PublicationPurchases { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<SavedPublication> SavedPublications { get; set; }

    }
}
