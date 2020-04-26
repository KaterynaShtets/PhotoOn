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
            PublicationImagies = new List<PublicationImage>();
            PublicationPurchases = new List<PublicationPurchase>();
            Likes = new List<Like>();
        }

        public string Title { get; set; }
        public decimal? Price { get; set; }
        public decimal coordX { get; set; }
        public decimal coordY { get; set; }
        public string PictureLink { get; set; }
        public DateTime PublicationDate { get; set; }
        public TimeOfTheYear Season { get; set; }
        public string TextDescription { get; set; }
        public int LikeCount { get; private set; }
        public bool IsApproved { get; set; }
        public ICollection<PublicationEquipment> PublicationEquipments { get; private set; }
        public ICollection<PublicationTag> PublicationTags { get; private set; }
        public ICollection<PublicationPurchase> PublicationPurchases { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<PublicationImage> PublicationImagies { get; set; }
        public ICollection<SavedPublication> SavedPublications { get; set; }

    }
}
