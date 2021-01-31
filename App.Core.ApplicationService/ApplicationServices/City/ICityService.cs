using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public interface ICityService
    {
        string Create(CityInsertInputDto inputDto);

        string Update(CityUpdateDto updateDto);

        Task<List<CityOutputDto>> GetAll();

        Task<CityOutputDto> GetSingel(int id);

        string Delete(int id);

    }
}