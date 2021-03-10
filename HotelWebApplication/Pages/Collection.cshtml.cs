using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.StarDto;
using Hotel.Core.ApplicationService.ApplicationServices.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelWebApplication.Pages
{
    public class CollectionModel : PageModel
    {
        private readonly IHotelService hotelService;
        private readonly ICityService cityService;
        private readonly IStarService starService;
        private readonly IHotelSearchService hotelSearchservice;

        public CollectionModel(IHotelService hotelService,
            ICityService cityService,
            IStarService starService,
            IHotelSearchService hotelSearchservice
            )
        {
            this.hotelService = hotelService;
            this.cityService = cityService;
            this.starService = starService;
            this.hotelSearchservice = hotelSearchservice;
        }
        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public List<HotelGetOutPutDto> Hotels { get; set; }
        public async Task OnGetAsync(string filterName="")
        {
            Hotels = await hotelService.GetAllHotels(filterName);
            var cityList = await cityService.GetAllCity();

        }


    }
}
