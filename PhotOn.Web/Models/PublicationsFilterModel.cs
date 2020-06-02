using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Models
{
    public class PublicationsFilterModel
    {
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; }
        public bool DescendingOrder { get; set; }

        public string Title { get; set; }
        public int? TagId { get; set; }
        public int? EquipmentId { get; set; }
        public bool isToday { get; set; }
    }
}
