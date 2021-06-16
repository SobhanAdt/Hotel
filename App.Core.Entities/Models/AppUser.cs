using System;
using System.Collections.Generic;
using System.Text;
using App.Core.ApplicationService.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Core.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public string UserName { get; set; }
    }
}
