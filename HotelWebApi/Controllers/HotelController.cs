using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService service;
        private IRepository<Hotel> repository;

        public HotelController(IHotelService service, IRepository<Hotel> repository)
        {
            this.service = service;
            this.repository = repository;
        }
        [HttpGet]
        public Task<List<HotelGetOutPutDto>> GetAll()
        {
            return service.GetAllHotels();

        }
        [HttpGet]
        public Task<HotelGetOutPutDto> Get(int id)
        {

            return service.GetSingleHotel(id);

        }
        [HttpPut]
        public async Task<IActionResult> Update(HotelUpdateInputDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            service.Update(updateDto);
            return Ok("Ok Update");
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelInsertInputDto inputDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            service.Create(inputDto);
            return Ok("OK Insert");
        }
    }
}
