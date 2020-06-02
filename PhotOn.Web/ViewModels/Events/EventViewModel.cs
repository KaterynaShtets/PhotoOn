using PhotOn.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Events
{
    public class EventViewModel
    {
        public DateTime DateTime { get; set; }
        public string TextDescription { get; set; }
        public string AwardTitle { get; set; }
        public TagDto Tag { get; set; }
    }
}
