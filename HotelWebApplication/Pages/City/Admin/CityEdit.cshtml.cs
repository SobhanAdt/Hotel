using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.Dtos.CityDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.City.Admin
{
    public class CityEditModel : PageModel
    {
        private ICityService CityService;

        public CityEditModel(ICityService cityService)
        {
            CityService = cityService;
        }

        [BindProperty]
        public CityUpdateDto CityUpdate { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await CityService.UpdateCity(CityUpdate);
            return Redirect("/City/Admin/ListCity");
        }

        [BindProperty]
        public CityOutputDto CitySingel { get; set; }
        public async Task OnGet(int id)
        {
            CitySingel =await CityService.GetSingelCity(id);
        }
    }
}
