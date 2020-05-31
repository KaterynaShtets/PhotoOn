using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhotOn.Application.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email{ get; set; }
        public DateTime DOB { get; set; } 
    }
}
