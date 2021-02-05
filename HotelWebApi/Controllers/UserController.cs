using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.User;
using App.Core.ApplicationService.Dtos.Userto;
using App.Core.ApplicationService.ApplicationServices.UserLogin;
using App.Core.ApplicationService.Dtos.UserLoginDto;

namespace HotelWebApi.Controllers
{
    /// <summary>
    /// User Crud Operation
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService service;
        private IUserLoginService userLoginService;


        public UserController(IUserService service, IUserLoginService userLoginService)
        {
            this.service = service;
            this.userLoginService = userLoginService;
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
                var InsertUser = await service.InsertUser(insertInputDto);
                return Ok(InsertUser);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            if (ModelState.IsValid)
            {
                var loginUser = await userLoginService.Login(login);
                return Ok(loginUser);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto updateDto)
        {
            if (ModelState.IsValid)
            {
                var UpdateUser = await service.UpdateUser(updateDto);
                return Ok(UpdateUser);
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            if (ModelState.IsValid)
            {
                var DeleteUser = await service.DeleteUser(id);
                return Ok(DeleteUser);
            }

            return BadRequest();
        }
    }
}
