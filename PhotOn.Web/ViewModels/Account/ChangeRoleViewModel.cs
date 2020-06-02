using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.ViewModels.Account
{
    public class ChangeRoleViewModel
    {
        public UserViewModel UserViewModel { get; set; }
        public IEnumerable<RoleViewModel> RoleViewModels { get; set; }
    }
}
