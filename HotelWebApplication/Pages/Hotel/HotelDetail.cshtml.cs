using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.Review;
using App.Core.ApplicationService.ApplicationServices.ReviewAnswer;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.ReviewAnswerDto;
using App.Core.ApplicationService.Dtos.ReviewDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HotelWebApplication.Pages
{
    public class HotelDetailModel : PageModel
    {
        private IHotelService _hotelService;

        private IReviewService reviewService;
        private IReviewAnswerService reviewAnswer;

        public HotelDetailModel(IHotelService hotelService, IReviewService reviewService, IReviewAnswerService reviewAnswer)
        {
            _hotelService = hotelService;
            this.reviewService = reviewService;
            this.reviewAnswer = reviewAnswer;
        }

        [BindProperty]
        public HotelGetOutPutDto hotel { get; set; }

        [BindProperty]
        public List<HotelGetOutPutDto> TopHotel { get; set; }

        [BindProperty]
        public List<ReviewGetOutPutDto> Reiviews { get; set; }

        [BindProperty]
        public List<ReviewAnswerGetOutPutDto> ReiviewAnswers { get; set; }

        public async Task OnGetAsync(int id)
        {
            hotel =await _hotelService.GetSingleHotel(id);

            TopHotel =await _hotelService.GetTopHotelRate();

            Reiviews =await reviewService.GetAllReviews();

            ReiviewAnswers = await reviewAnswer.GetAllReviews();
        }


        public ReviewInsertInputDto InsertReview { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await reviewService.Create(InsertReview, 1);

            return Redirect("/Hotel/HotelDetail" + InsertReview.HotelId);
        }
    }
}
