using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class HotelDeleteModel : PageModel
    {
        private IHotelService hotelService;
        public HotelDeleteModel(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }
        [BindProperty]
        public int Id { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await hotelService.DeleteHotels(Id);
             return RedirectToPage("/Index");  
        }
    }
}
