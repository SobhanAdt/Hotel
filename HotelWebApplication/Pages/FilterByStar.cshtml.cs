using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Rate;
using App.Core.ApplicationService.Dtos.StarDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class FilterByStarModel : PageModel
    {
        private readonly IStarService service;

        public FilterByStarModel(IStarService service)
        {
            this.service = service;
        }

        [BindProperty]
        public Task<List<StarOutputDto>> ListStar { get; set; }
        public void OnGet()
        {
            ListStar = service.GetAllStar();
        }
    }
}
