using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotOn.Web.Models
{
    public class RoleName
    {
        public const string User = "User";
        public const string Expert = "Expert";
        public const string Admin = "Admin";
        public const string Banned = "Banned";
        public const string AdminAndExpert = "Admin, Expert";
        public const string NotBannedUsers = "Admin, Expert, User";
        public const string AllUsers = "Admin, Expert, User, Bunned";
    }
}
