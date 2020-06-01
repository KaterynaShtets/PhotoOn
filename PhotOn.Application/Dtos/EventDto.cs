using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Dtos
{
    public class EventDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string TextDescription { get; set; }
        public string AwardTitle { get; set; }
        public TagDto Tag { get; set; }
    }
}
