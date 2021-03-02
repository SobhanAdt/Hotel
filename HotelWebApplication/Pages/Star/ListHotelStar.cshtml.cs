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
    public class ListHotelStarModel : PageModel
    {
        private IStarService starService;

        public ListHotelStarModel(IStarService starService)
        {
            this.starService = starService;
        }


        public StarOutputDto Star { get; set; }
        public async Task OnGetAsync(int id)
        {
            Star = await starService.GetSingelStar(id);

        }
    }
}
