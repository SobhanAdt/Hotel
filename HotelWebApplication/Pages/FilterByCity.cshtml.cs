using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.Dtos.CityDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class FilterByCityModel : PageModel
    {
        private readonly ICityService service;

        public FilterByCityModel(ICityService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Task<List<CityOutputDto>> ListCity { get; set; }
        public void OnGet()
        {
            ListCity = service.GetAllCity();
        }
    }
}
