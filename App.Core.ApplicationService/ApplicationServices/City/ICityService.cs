using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public interface ICityService
    {
        Task<string> CreateCity(CityInsertInputDto inputDto);

        Task<string> UpdateCity(CityUpdateDto updateDto);

        Task<List<CityOutputDto>> GetAllCity();

        Task<CityOutputDto> GetSingelCity(int id);

        Task<string> DeleteCity(int id);

    }
}