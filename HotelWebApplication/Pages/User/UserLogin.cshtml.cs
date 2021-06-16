using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.UserLogin;
using App.Core.ApplicationService.Dtos.UserLoginDto;
using Hotel.Core.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelWebApplication.Pages.User
{
    public class UserLoginModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILogger<RegisterUserModel> _logger;

        public UserLoginModel(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterUserModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._logger = logger;
        }
        [BindProperty]
        public LoginDto Input { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, 
                // set lockoutOnFailure: true
                var result = await signInManager.PasswordSignInAsync(Input.Email,
                    Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
