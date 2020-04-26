using PhotOn.Core.Entities.Base;

namespace PhotOn.Core.Entities
{
    public enum Priority
    {
        None,
        High,
        Low,
    }

    public class PublicationImage : Entity
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public string ImageLink { get; set; }
        public Priority Priority { get; set; }
    }
}
