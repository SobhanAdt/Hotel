using App.Core.ApplicationService.ApplicationServices.Review;
using App.Core.ApplicationService.ApplicationServices.ReviewAnswer;
using App.Core.ApplicationService.Dtos.ReviewAnswerDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.UserLogin;

namespace HotelWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewAnswerController : ControllerBase
    {
        private IReviewAnswerService service;
        private IUserLoginService userLoginService;


        public ReviewAnswerController(IReviewAnswerService service, IUserLoginService userLoginService)
        {
            this.service = service;
            this.userLoginService = userLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var AllReviewAnswer = await service.GetAllReviews();
                return Ok(AllReviewAnswer);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var SingelReviewAnswer = await service.GetSingleReview(id);
                return Ok(SingelReviewAnswer);
            }

            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewAnswerUpdateInputDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var updateReviewAnswer = service.Update(updateDto);
                return Ok(updateReviewAnswer);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewAnswerInsertInputDto inputDto,[FromHeader] string token)
        {
            userLoginService.ValidateUser(token);
            if (ModelState.IsValid)
            {
                var insertReviewAnswer = service.Create(inputDto);
                return Ok(insertReviewAnswer);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var deleteReviewAnswer = service.DeleteReview(id);
                return Ok(deleteReviewAnswer);
            }

            return BadRequest();
        }
    }
}

