using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.StarDto;

namespace HotelWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IHotelService hotelService;
        private readonly IStarService starService;


        public IndexModel(ILogger<IndexModel> logger, IHotelService hotelService, IStarService starService)
        {
            _logger = logger;
            this.hotelService = hotelService;
            this.starService = starService;
        }

        [BindProperty]
        public List<HotelGetOutPutDto> ListTopHotel { get; set; }

        [BindProperty]
        public Task<List<HotelGetOutPutDto>> ListNewHotel { get; set; }

        [BindProperty] 
        public List<StarOutputDto> ListStar { get; set; }

        public void OnGet()
        {
            ListTopHotel = hotelService.GetTopHotelRate();

            ListNewHotel = hotelService.fourNewInsertHotel();

            
        }
    }
}
