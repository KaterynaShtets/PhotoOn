using PhotOn.Core.Entities.Base;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public class Equipment : Entity
    {
        public Equipment()
        {
            PublicationEquipment = new List<PublicationEquipment>();
        }
        public string Title { get; set; }
        public ICollection<PublicationEquipment> PublicationEquipment { get; private set; }
    }
}
