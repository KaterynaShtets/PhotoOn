using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Models
{
    public class PublicationsFilterModel
    {
        public string searchString { get; set; }
        public string sortOrder { get; set; }
        public int fiterOption { get; set; }
    }
}
