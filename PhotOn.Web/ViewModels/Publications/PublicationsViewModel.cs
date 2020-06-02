using PhotOn.Web.Models;
using System.Collections.Generic;

namespace PhotOn.Web.ViewModels.Publications
{
    public class PublicationsViewModel
    {
        public IEnumerable<PublicationViewModel> Publications { get; set; }

        public PublicationsFilterModel FilterModel { get; set; }
    }
}