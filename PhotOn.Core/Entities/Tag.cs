using PhotOn.Core.Entities.Base;
using System.Collections.Generic;

namespace PhotOn.Core.Entities
{
    public class Tag : Entity
    {
        public Tag()
        {
            PublicationTags = new List<PublicationTag>();
        }
        public string Title { get; set; }
        public ICollection<PublicationTag> PublicationTags { get; private set; }
    }
}
