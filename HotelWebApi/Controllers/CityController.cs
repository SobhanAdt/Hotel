using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.City;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using Microsoft.IdentityModel.Tokens;

namespace HotelWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICityService service;
        private IRepository<City> repository;

        public CityController(ICityService service, IRepository<City> repository)
        {
            this.service = service;
            this.repository = repository;
        }

        [HttpPut]
        public async Task<IActionResult> Update(CityUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            service.Update(updateDto);
            return Ok("Ok Update");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityInsertInputDto inputDto)
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
