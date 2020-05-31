using PhotoOn.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Models
{
    public class PublicationFilterModel
    {
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
        public PaginationModel Pagination
        {
            get {return new PaginationModel() { Page = Page, RecordsPerPage = RecordsPerPage = RecordsPerPage }; }
        }

        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; }
        public bool DescendingOrder { get; set; }
        
        public string Title { get; set; }
        public int? TagId { get; set; }
        public int? EquipmentId { get; set; }
        public bool isToday { get; set; }
    }
}
