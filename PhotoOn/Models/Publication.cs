using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public int NumberOfViews { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
