using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
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
        public List<HotelGetOutPutDto> Compare { get; set; }
        public async Task OnGetAsync(int id)
        {
            var input =new HotelCompareInputDto();
            input.Hotels=new List<int>();
            input.Hotels.Add(id);
            Compare = _hotelService.HotelCompare(input);
        }
    }
}