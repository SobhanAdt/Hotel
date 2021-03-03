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
    public class CityCreateModel : PageModel
    {
        private ICityService cityService;

        public CityCreateModel(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [BindProperty]
        public CityInsertInputDto CityInsert { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await cityService.CreateCity(CityInsert);
            return Redirect("/City/Admin/ListCity");
        }
    }
}
