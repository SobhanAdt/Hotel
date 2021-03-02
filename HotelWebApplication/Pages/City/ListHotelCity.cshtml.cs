using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.City
{
    public class ListHotelCityModel : PageModel
    {
        private ICityService cityService;

        public ListHotelCityModel(ICityService cityService)
        {
            this.cityService = cityService;
        }


        public CityOutputDto CityHotel { get; set; }
        public async Task OnGetAsync(int id)
        {
            CityHotel =await cityService.GetSingelCity(id);

        }
    }
}
