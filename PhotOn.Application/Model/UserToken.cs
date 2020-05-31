using System;
using System.Collections.Generic;
using System.Text;

namespace PhotOn.Application.Models
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
