using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.Hotel.Admin
{
    public class HotelCreateModel : PageModel
    {
        private IHotelService hotelService;

        public HotelCreateModel(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [BindProperty]
        public HotelInsertInputDto InputDto { get; set; }
        public async  Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await hotelService.Create(InputDto);
            return Redirect("/Hotel/Admin/ListHotel");
        }
    }
}
