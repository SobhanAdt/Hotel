using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Rate;

namespace HotelWebApi.Controllers
{
    /// <summary>
    ///  Just Get Info About Hotel's Star
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {
        private readonly IStarService service;

        public StarController(IStarService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                var rateAll =  service.GetAllStar();
                return Ok(rateAll);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var singelRate = await service.GetSingelStar(id);
                return Ok(singelRate);
            }

            return BadRequest();
        }
    }
}
