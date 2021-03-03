using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.City.Admin
{
    public class CityDeleteModel : PageModel
    {
        private ICityService cityService;

        public CityDeleteModel(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [BindProperty]
        public int id  { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await cityService.DeleteCity(id);
            return Redirect("/City/Admin/ListCity");
        }
    }
}
