using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.Hotel
{
    public class ListHotelModel : PageModel
    {
        private IHotelService hotelService;

        public ListHotelModel(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [BindProperty]
        public List<HotelGetOutPutDto> ListHotel { get; set; }


        public async Task OnGetAsync()
        {
            ListHotel =await hotelService.GetAllHotels();
        }
    }
}
