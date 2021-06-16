using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hotel.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace HotelWebApplication.Claims
{
    public class AdditionalUserClaimsPrincipalFactory
        : UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public AdditionalUserClaimsPrincipalFactory(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(AppUser user)
        {
            var principal = await base.CreateAsync(user);
            var identity = (ClaimsIdentity)principal.Identity;
            var roles = await UserManager.GetRolesAsync(user);
            var claims = new List<Claim>();
            if (roles.Contains(AppRole.Admin.ToString()))
            {
                claims.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "user"));
            }

            identity.AddClaims(claims);
            return principal;
        }
    }
}
