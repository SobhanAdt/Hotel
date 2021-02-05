using App.Core.ApplicationService.ApplicationServices.Review;
using App.Core.ApplicationService.Dtos.ReviewDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.UserLogin;

namespace HotelWebApi.Controllers
{
    /// <summary>
    /// Review Crud Operation
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private IReviewService service;
        private IUserLoginService userLoginService;


        public ReviewController(IReviewService service, IUserLoginService userLoginService)
        {
            this.service = service;
            this.userLoginService = userLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var AllReview = await service.GetAllReviews();
                return Ok(AllReview);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var SingelReview = await service.GetSingleReview(id);
                return Ok(SingelReview);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ReviewUpdateInputDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var updateReview = await service.Update(updateDto);
                return Ok(updateReview);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReviewInsertInputDto inputDto, [FromHeader] string token)
        {
            await userLoginService.ValidateUser(token);

            if (ModelState.IsValid)
            {
                var insertReview = await service.Create(inputDto);
                return Ok(insertReview);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var deleteReview = await service.DeleteReview(id);
                return Ok(deleteReview);
            }

            return BadRequest();
        }
    }
}
