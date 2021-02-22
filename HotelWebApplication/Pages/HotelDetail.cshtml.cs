using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class HotelDetailModel : PageModel
    {
        private IHotelService _hotelService;

        public HotelDetailModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [BindProperty]
        public Task<HotelGetOutPutDto> hotel { get; set; }
        public void OnGet()
        {
            hotel = _hotelService.GetSingleHotel(hotel.Id);
        }
    }
}
