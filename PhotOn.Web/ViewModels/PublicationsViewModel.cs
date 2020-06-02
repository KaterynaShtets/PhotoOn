using PhotOn.Application.Models;
using System.Collections.Generic;

namespace PhotOn.Web.ViewModels
{
    public class PublicationsViewModel
    {
        public IEnumerable<PublicationViewModel> Publications { get; set; }

        //public PublicationFilterModel FilterModel { get; set; }
    }
}