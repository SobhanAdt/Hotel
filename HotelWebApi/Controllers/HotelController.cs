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
    [Route("[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var AllHotel = await service.GetAllHotels();
                return Ok(AllHotel);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var SingelHotel = await service.GetSingleHotel(id);
                return Ok(SingelHotel);
            }

            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(HotelUpdateInputDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var updateHotel = service.Update(updateDto);
                return Ok(updateHotel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelInsertInputDto inputDto)
        {
            if (ModelState.IsValid)
            {
                var insertHotel = service.Create(inputDto);
                return Ok(insertHotel);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var deleteHotel =  service.DeleteHotels(id);
                return Ok(deleteHotel);
            }

            return BadRequest();
        } 
    }
}
