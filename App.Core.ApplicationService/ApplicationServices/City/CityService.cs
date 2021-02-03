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
        private IRepository<Entities.Hotel> hotelRepository;

        public CityService(IRepository<Entities.City> repository, IRepository<Entities.Hotel> hotelRepository)
        {
            this.repository = repository;
            this.hotelRepository = hotelRepository;
        }

        public string CreateCity(CityInsertInputDto inputDto)
        {
            repository.Insert(new Entities.City()
            {
                CityName = inputDto.CityName
            });
            repository.Save();
            return $"Ba Mofaghiyat {inputDto.CityName} Afzode shod";
        }

        public string UpdateCity(CityUpdateDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.CityName = updateDto.CityName;
            repository.Save();
            return $"Update Ba Mofaghiyat Anjam Shod";
        }

        public async Task<List<CityOutputDto>> GetAllCity()
        {
            var lst = repository.GetQuery().Include(x => x.Hotels);
            return lst.Select(x => new CityOutputDto()
            {
                CityName = x.CityName,
                Id = x.Id,
                Hotels = x.Hotels.Select(y => new HotelDTO()
                {
                    Description =  y.Description ,
                    HotelCode = y.HotelCode ,
                    HotelName =  y.HotelName,
                    Id =  y.Id ,
                    RoomCount = y.RoomCount
                }).ToList()
            }).ToList();
        }

        public async Task<CityOutputDto> GetSingelCity(int id)
        {
            var item =await repository.GetQuery().
                Include(x => x.Hotels).FirstOrDefaultAsync(x=>x.Id==id);

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
                    RateId = x.RateId,
                    RoomCount = x.RoomCount
                }).ToList()
            };
        }
        public string DeleteCity(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "Delete Anjam shod";
        }
    }
}