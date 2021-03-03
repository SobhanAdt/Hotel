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
    public class ListCityModel : PageModel
    {
        private ICityService cityService;

        public ListCityModel(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [BindProperty]
        public List<CityOutputDto> Cites { get; set; }
        public async Task OnGetAsync()
        {
            Cites =await cityService.GetAllCity();
        }
    }
}
