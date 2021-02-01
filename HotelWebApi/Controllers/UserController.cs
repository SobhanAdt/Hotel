using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.Dtos.Userto;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                var ListUser = await service.GetAllUser();
                return Ok(ListUser);
            }

            return BadRequest();

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var SingelUser = await service.GetSingelUser(id);
                return Ok(SingelUser);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserInsertInputDto insertInputDto)
        {
            if (ModelState.IsValid)
            {
                var InsertUser = service.InsertUser(insertInputDto);
                return Ok(InsertUser);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var UpdateUser = service.UpdateUser(updateDto);
                return Ok(UpdateUser);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var DeleteUser = service.DeleteUser(id);
                return Ok(DeleteUser);
            }

            return BadRequest();
        }
    }
}
