namespace PhotOn.Core.Entities
{
    public class PublicationEquipment
    {
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }

        public int EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}
