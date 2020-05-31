using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Models
{
    public class PublicationDetailsModel : PublicationModel
    {
        public IEnumerable<EquipmentModel> EquipmentModels { get; private set; }
        public IEnumerable<TagModel> TagModels { get; private set; }
    }
}
