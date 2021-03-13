using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using Hotel.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.Hotel
{
    public class CompareModel : PageModel
    {
        private IHotelService _hotelService;


        public CompareModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [BindProperty]
        public HotelCompareInputDto Compare { get; set; }
        public  void OnGet()
        {
            Compare = _hotelService.HotelCompare();
        }
    }
}
