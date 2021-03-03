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
    public class CityDetailModel : PageModel
    {
        private ICityService cityService;

        public CityDetailModel(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [BindProperty]
        public CityOutputDto City { get; set; }
        public async Task OnGetAsync(int id)
        {
            City =await cityService.GetSingelCity(id);
        }
    }
}
