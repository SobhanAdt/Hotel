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
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService service;
        private IRepository<Room> repository;

        public RoomController(IRoomService service, IRepository<Room> repository)
        {
            this.service = service;
            this.repository = repository;
        }
        [HttpGet]
        public Task<List<RoomGetOutPutDto>> GetAll()
        {
            return service.GetAllRooms();

        }
        [HttpGet]
        public Task<RoomGetOutPutDto> Get(int id)
        {

            return service.GetSingleRooms(id);

        }
        [HttpPut]
        public async Task<IActionResult> Update(RoomUpdateInputDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            service.Update(updateDto);
            return Ok("Ok Update");
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomInsertInputDto inputDto)
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
