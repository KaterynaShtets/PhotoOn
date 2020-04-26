namespace PhotOn.Core.Entities
{
    public class PublicationTag
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
