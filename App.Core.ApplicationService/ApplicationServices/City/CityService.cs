﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public class CityService : ICityService
    {
        private IRepository<Entities.City> repository;

        public CityService(IRepository<Entities.City> repository)
        {
            this.repository = repository;

        }

        public async Task<string> CreateCity(CityInsertInputDto inputDto)
        {
            var cityValidate = await repository.GetQuery().
                Where(w => w.CityName == inputDto.CityName).FirstOrDefaultAsync();

            if (cityValidate == null)
            {
                repository.Insert(new Entities.City()
                {
                    CityName = inputDto.CityName
                });
                await repository.Save();
                return $"Ba Mofaghiyat {inputDto.CityName} Afzode shod";
            }

            throw new Exception("in City Vojod darad");
        }

        public async Task<string> UpdateCity(CityUpdateDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.CityName = updateDto.CityName;
            await repository.Save();
            return $"Update Ba Mofaghiyat Anjam Shod";
        }

        public async Task<List<CityOutputDto>> GetAllCity()
        {
            var lst = repository.GetQuery().Include(x => x.Hotels);
            return await lst.Select(x => new CityOutputDto()
            {
                CityName = x.CityName,
                Id = x.Id,
                Hotels = x.Hotels.Select(y => new HotelDTO()
                {
                    Description = y.Description,
                    HotelCode = y.HotelCode,
                    HotelName = y.HotelName,
                    Id = y.Id,
                    RoomCount = y.RoomCount
                }).ToList()
            }).ToListAsync();
        }

        public async Task<CityOutputDto> GetSingelCity(int id)
        {
            var item = await repository.GetQuery().
                Include(x => x.Hotels)
                .Where(w=>w.Id==id).FirstOrDefaultAsync();

            return new CityOutputDto()
            {
                Id = item.Id,
                CityName = item.CityName,
                Hotels = item.Hotels.Select(x => new HotelDTO()
                {
                    Description = x.Description,
                    HotelCode = x.HotelCode,
                    HotelName = x.HotelName,
                    Id = x.Id,
                    StarId = x.StarId,
                    RoomCount = x.RoomCount
                }).ToList()
            };
        }
        public async Task<string> DeleteCity(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }
    }
}