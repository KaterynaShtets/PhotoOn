using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PhotoOn.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; } // возраст пользователя

        public float Balance { get; set; }
    }
}
