using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Models
{
    public class PublicationTag
    {
        public int Id { get; set; }
        public Publication Publication { get; set; }
        public Tag Tag { get; set; }
    }
}
