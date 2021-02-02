using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public interface ICityService
    {
        string CreateCity(CityInsertInputDto inputDto);

        string UpdateCity(int id,CityUpdateDto updateDto);

        Task<List<CityOutputDto>> GetAllCity();

        Task<CityOutputDto> GetSingelCity(int id);

        string DeleteCity(int id);

    }
}