using System.Collections.Generic;
using App.Core.ApplicationService.Dtos.CityDto;

namespace App.Core.ApplicationService.ApplicationServices.City
{
    public interface ICityService
    {
        string Create(CityInsertInputDto inputDto);

        string Update(CityUpdateDto updateDto);

        List<CityOutputDto> GetAll();

    }
}