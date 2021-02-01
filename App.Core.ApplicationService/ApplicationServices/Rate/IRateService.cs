using System.Collections.Generic;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.RateDto;

namespace App.Core.ApplicationService.ApplicationServices.Rate
{
    public interface IRateService
    {
        Task<List<RateOutputDto>> GetAllRate();

        Task<RateOutputDto> GetSingelRate(int id);
    }
}