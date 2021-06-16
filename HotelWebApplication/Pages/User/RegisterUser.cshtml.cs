using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.Dtos.Userto;
using Hotel.Core.Entities.Models;
using HotelWebApplication.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HotelWebApplication.Pages.User
{
    [AllowAnonymous]
    public class RegisterUserModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterUserModel> _logger;

        public RegisterUserModel(SignInManager<AppUser>
            signInManager, UserManager<AppUser> userManager
            , ILogger<RegisterUserModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public UserInsertInputDto InsertInputDto { get; set; }
        public string ReturnUrl { get; set; }



        public Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            return Task.CompletedTask;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FullName = InsertInputDto.FullName,
                    UserName = InsertInputDto.UserName,
                    Email = InsertInputDto.Email
                };


                var result = await _userManager.CreateAsync(user, InsertInputDto.Password);
                await _userManager.AddToRoleAsync(user, "User");
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
