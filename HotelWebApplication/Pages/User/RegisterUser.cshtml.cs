using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.Dtos.Userto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class RegisterUserModel : PageModel
    {
        private IUserService userService;

        public RegisterUserModel(IUserService userService)
        {
            this.userService = userService;
        }



        [BindProperty]
        public UserInsertInputDto InsertInputDto { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await userService.InsertUser(InsertInputDto);
            return RedirectToPage("/User/UserLogin");
        }
    }
}
