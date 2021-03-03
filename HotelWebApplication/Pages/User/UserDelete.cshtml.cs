using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.Dtos.Userto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.User
{
    public class UserDeleteModel : PageModel
    {
        private IUserService userService;
        public UserDeleteModel(IUserService userService)
        {
            this.userService = userService;
        }
        [BindProperty]
        public UserOutputDto user { get; set; }

        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            user = await userService.GetSingelUser(id);
            await userService.DeleteUser(id);
            return RedirectToPage("/Index");
        }
    }
}
