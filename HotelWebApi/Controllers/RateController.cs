﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.ApplicationServices.Rate;

namespace HotelWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RateController : ControllerBase
    {
        private IRateService service;

        public RateController(IRateService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (ModelState.IsValid)
            {
                var rateAll = await service.GetAllRate();
                return Ok(rateAll);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (ModelState.IsValid)
            {
                var singelRate = await service.GetSingelRate(id);
                return Ok(singelRate);
            }

            return BadRequest();
        }
    }
}
