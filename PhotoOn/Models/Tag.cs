using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public IEnumerable<Publication> Publications { get; set; }
    }
}
