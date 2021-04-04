using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.StarDto;

namespace HotelWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHotelService hotelService;
        private readonly IStarService starService;
        private readonly ICityService cityService;


        public IndexModel(ILogger<IndexModel> logger, IHotelService hotelService
            , IStarService starService, ICityService cityService)
        {
            _logger = logger;
            this.hotelService = hotelService;
            this.starService = starService;
            this.cityService = cityService;
        }

        [BindProperty]
        public List<HotelGetOutPutDto> ListTopHotel { get; set; }

        [BindProperty]
        public List<HotelGetOutPutDto> ListNewHotel { get; set; }

        [BindProperty]
        public List<StarOutputDto> ListStar { get; set; }

        [BindProperty]
        public List<CityOutputDto> ListCity { get; set; }


        public async Task OnGet()
        {
            ListTopHotel = await hotelService.GetTopHotelRate();

            ListNewHotel = await hotelService.fourNewInsertHotel();

            ListStar = await starService.GetAllStar();

            ListCity = await cityService.GetAllCity();
        }
    }
}
