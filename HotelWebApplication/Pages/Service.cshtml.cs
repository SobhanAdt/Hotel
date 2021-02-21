using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly IHotelService hotelService;
        public ServiceModel(IHotelService hotelService )
        {
            this.hotelService = hotelService;
        }
        [BindProperty]
        public List<HotelGetOutPutDto> Hotels { get; set; }
        public void OnGet()
        {
            Hotels = hotelService.GetAllHotels();
        }
    }
}
