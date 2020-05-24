using PhotOn.Core.Entities.Base;
using System;

namespace PhotOn.Core.Entities
{
    public class PublicationPurchase : Entity
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
