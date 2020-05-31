using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Model.Dtos
{
    public class UserCreationDto
    {
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Password { get; set; }
    }
}
