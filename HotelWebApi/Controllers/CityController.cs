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
            if (ModelState.IsValid)
            {
                var UpdateCity = service.UpdateCity(updateDto);
                return Ok(UpdateCity);
            }
            return BadRequest();


        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityInsertInputDto inputDto)
        {
            if (ModelState.IsValid)
            {
                var InsertCity = service.CreateCity(inputDto);
                return Ok(InsertCity);

            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            if (ModelState.IsValid)
            {
                var lstCity = await service.GetAllCity();
                return Ok(lstCity);
            }

            return BadRequest();

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var item = await service.GetSingelCity(id);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var DeleteCity = service.DeleteCity(id);
                return Ok(DeleteCity);
            }

            return BadRequest();

        }

    }
}
