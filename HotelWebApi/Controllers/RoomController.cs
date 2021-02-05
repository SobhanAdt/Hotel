using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Room;
using App.Core.ApplicationService.Dtos.RoomDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    /// <summary>
    /// Room Crud Operation
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService service;

        public RoomController(IRoomService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (ModelState.IsValid)
            {
                var AllRoom = await service.GetAllRooms();
                return Ok(AllRoom);
            }

            return BadRequest();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var SingelRoom = await service.GetSingleRooms(id);
                return Ok(SingelRoom);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoomUpdateInputDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var updateRoom = await service.Update(updateDto);
                return Ok(updateRoom);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomInsertInputDto inputDto)
        {
            if (ModelState.IsValid)
            {
                var insertRoom = await service.Create(inputDto);
                return Ok(insertRoom);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var deleteRoom = await service.DeleteRooms(id);
                return Ok(deleteRoom);
            }

            return BadRequest();
        }
    }
}
