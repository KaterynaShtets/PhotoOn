using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoOn.Models
{
    public class UserBuyPublication
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Publication Publication { get; set; }
        public DateTime DateTime { get; set; }
    }
}
