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
        public HotelGetOutPutDto hotel { get; set; }
        public async Task OnGetAsync(int id)
        {
            hotel =await _hotelService.GetSingleHotel(id);
        }
    }
}
