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
    public class UserEditModel : PageModel
    {
        private IUserService userService;

        public UserEditModel(IUserService userService)
        {
            this.userService = userService;
        }

        [BindProperty]
        public UserUpdateDto update { get; set; }

        [BindProperty]
        public UserOutputDto user { get; set; }
        public async Task<IActionResult> OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           user = await userService.GetSingelUser(id);
            update.Id = user.Id;
            await userService.UpdateUser(update);

            return RedirectToPage("/Index");
        }
    }
}
