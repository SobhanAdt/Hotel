using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.Dtos.StarDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages.Star
{
    public class DetalisStarModel : PageModel
    {
        private IStarService starService;

        public DetalisStarModel(IStarService starService)
        {
            this.starService = starService;
        }

        public StarOutputDto star { get; set; }
        public async Task OnGetAsync(int id)
        {
            star = await starService.GetSingelStar(id);
        }
    }
}
