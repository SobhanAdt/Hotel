using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.UserLogin;
using App.Core.ApplicationService.Dtos.UserLoginDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.User
{
    public class UserLoginModel : PageModel
    {
        private IUserLoginService userLoginService;
        public UserLoginModel(IUserLoginService userLoginService)
        {
            this.userLoginService = userLoginService;
        }
        [BindProperty]
        public LoginDto login { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await userLoginService.LoginUser(login);
            if (user != null)
            {
                await userLoginService.Login(login);
                return RedirectToPage("/Index");
            }
            ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
            return Page();
        }
    }
}
