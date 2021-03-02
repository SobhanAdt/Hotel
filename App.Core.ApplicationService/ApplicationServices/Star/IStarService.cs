using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.StarDto;
using Hotel.Core.ApplicationService.Dtos.StarDto;

namespace App.Core.ApplicationService.ApplicationServices.Rate
{
    public interface IStarService
    {
        Task<List<StarOutputDto>> GetAllStar();

        Task<StarOutputDto> GetSingelStar(int id);

        Task<string> UpdateStar(StarUpdateDto updateDto);
    }
}