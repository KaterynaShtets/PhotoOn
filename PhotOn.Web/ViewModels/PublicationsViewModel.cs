using PhotOn.Application.Models;
using PhotOn.Web.ViewModels;
using System.Collections.Generic;

namespace PhotOn.Web.Models
{
    public class PublicationsViewModel
    {
        public IEnumerable<PublicationViewModel> Publications { get; set; }

        public PublicationFilterModel FilterModel { get; set; }
    }
}