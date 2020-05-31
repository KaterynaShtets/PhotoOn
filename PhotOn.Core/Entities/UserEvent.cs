using System;

namespace PhotOn.Core.Entities
{
    public class UserEvent
    {
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public DateTime AccomplishmentDate { get; set; }
    }
}
