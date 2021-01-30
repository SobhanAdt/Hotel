using System.Collections.Generic;
using System.Runtime.InteropServices;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public class CityService : ICityService
    {
        private IRepository<Entities.City> repository;

        public CityService(IRepository<Entities.City> repository)
        {
            this.repository = repository;
        }

        public string Create(CityInsertInputDto inputDto)
        {
            repository.Insert(new Entities.City()
            {
                CityName = inputDto.Name
            });
            repository.Save();
            return $"Ba Mofaghiyat {inputDto.Name} Afzode shod";
        }

        public string Update(CityUpdateDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.Result.CityName = updateDto.Name;
            repository.Save();
            return $"Update Ba Mofaghiyat Anjam Shod";
        }

        public List<CityOutputDto> GetAll()
        {
            var list = repository.GetAll();

        }
    }
}