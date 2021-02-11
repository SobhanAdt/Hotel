using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Core.ApplicationService.ApplicationServices.Hotel;
using App.Core.ApplicationService.ApplicationServices.UserLogin;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using Hotel.Core.ApplicationService.Dtos.HotelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace HotelWebApi.Controllers
{
    /// <summary>
    /// Hotel Crud Operation
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if (ModelState.IsValid)
            {
                var AllHotel = service.GetAllHotels();
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

        [HttpGet]
        public async Task<IActionResult> GetSixNewHotel()
        {
            if (ModelState.IsValid)
            {
                var SixNewHotel = await service.SixNewInsertHotel();
                return Ok(SixNewHotel);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] HotelUpdateInputDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var updateHotel = await service.Update(updateDto);
                return Ok(updateHotel);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HotelInsertInputDto inputDto)
        {
            if (ModelState.IsValid)
            {
                var insertHotel = await service.Create(inputDto);
                return Ok(insertHotel);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var deleteHotel = await service.DeleteHotels(id);
                return Ok(deleteHotel);
            }

            return BadRequest();
        }
        [HttpPost]
        public IActionResult Compare([FromBody] HotelCompareInputDto input)
        {
            if (ModelState.IsValid)
            {
                var HotelsCompare = service.HotelCompare(input);
                return Ok(HotelsCompare);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult TopHotel()
        {
            if (ModelState.IsValid)
            {
                var top = service.GetTopHotelRate();
                return Ok(top);
            }

            return BadRequest();
        }
    }
}
