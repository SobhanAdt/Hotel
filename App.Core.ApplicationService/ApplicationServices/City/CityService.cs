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

        public CityService(IRepository<Entities.City> repository,IRepository<Entities.Hotel> hotelRepository)
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
            var lst = repository.GetQuery().Include(x=>x.Hotels);
            return lst.Select(x => new CityOutputDto()
            {
                CityName = x.CityName,
                Id = x.Id,
                Hotels = x.Hotels
            }).ToList();
        }

        public async Task<CityOutputDto> GetSingelCity(int id)
        {
            var item = repository.GetSingel(id);
            var ListItem = hotelRepository.GetQuery().Where(x => x.CityId == id).ToList();
            return new CityOutputDto()
            {
                CityName = item.CityName,
                Id = item.Id,
                Hotels = ListItem
            };
        }
        public string DeleteCity(int id)
        {
            var item = repository.Delete(id);
            repository.Save();
            return "Delete Anjam shod";
        }
    }
}