using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelWebApplication.Claims
{
    public enum AppRole
    {
        Admin,
        User
    }
    public class RoleNames
    {
        public const string Admin = nameof(Admin);
        public const string User = nameof(User);
        public static string GetName(AppRole role) =>
            role switch
            {
                AppRole.Admin => Admin,
                AppRole.User => User,
                _ => ""
            };
    }
}
