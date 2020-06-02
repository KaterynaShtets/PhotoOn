using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Account
{
    public class UsersViewModel
    {
        public IEnumerable<UserViewModel> UserViewModels { get; set; }
    }
}
