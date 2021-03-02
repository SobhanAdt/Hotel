using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Rate;
using Hotel.Core.ApplicationService.Dtos.StarDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;

namespace HotelWebApplication.Pages.Star
{
    public class EditStarModel : PageModel
    {
        private IStarService starService;

        public EditStarModel(IStarService starService)
        {
            this.starService = starService;
        }

        [BindProperty]
        public StarUpdateDto StarUpdateDto { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            StarUpdateDto.Id = id;
            await starService.UpdateStar(StarUpdateDto);
            return Redirect("/Star/ListStar");
        }
    }
}
