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
    public class ListStarModel : PageModel
    {
        private IStarService starService;

        public ListStarModel(IStarService straService)
        {
            this.starService = straService;
        }

        [BindProperty]
        public List<StarOutputDto> StarList { get; set; }
        public async Task OnGetAsync()
        {
            StarList =await starService.GetAllStar();
        }
    }
}
