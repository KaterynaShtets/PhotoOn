using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotOn.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
    }
}
