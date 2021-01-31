using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public class CityService : ICityService
    {
        private IRepository<Entities.City> repository;
        private IMapper mapper;

        public CityService(IRepository<Entities.City> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public string CreateCity(CityInsertInputDto inputDto)
        {
            repository.Insert(new Entities.City()
            {
                CityName = inputDto.CityName
            });
            //var item = mapper.Map<Entities.City>(inputDto);
            //repository.Insert(item);
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
            var lst = repository.GetAll();
            return lst.Select(x => new CityOutputDto()
            {
                CityName = x.CityName,
                Id = x.Id
            }).ToList();

        }

        public async Task<CityOutputDto> GetSingelCity(int id)
        {
            var item = repository.GetSingel(id);
            return new CityOutputDto()
            {
                CityName = item.CityName,
                Id = item.Id
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