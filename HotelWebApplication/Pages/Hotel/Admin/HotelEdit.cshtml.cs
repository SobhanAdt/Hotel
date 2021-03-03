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
    public class HotelEditModel : PageModel
    {
        private IHotelService hotelService;
        public HotelEditModel(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [BindProperty]
        public HotelUpdateInputDto update { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await hotelService.Update(update);
            return RedirectToPage("/Index");
        }
    }
}
