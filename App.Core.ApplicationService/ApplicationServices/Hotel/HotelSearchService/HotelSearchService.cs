using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Core.ApplicationService.ApplicationServices.Hotel
{
    public class HotelSearchService : IHotelSearchService
    {
        private IRepository<App.Core.Entities.Hotel> repository;
        private IRepository<App.Core.Entities.UserRate> userRateRepository;
        public HotelSearchService(IRepository<App.Core.Entities.Hotel> repository)
        {
            this.repository = repository;
        }
        public  Task<List<HotelGetOutPutDto>> SearchByHotelName(string name)
        {
           return repository.GetQuery().Include(x => x.City).Where(x => x.HotelName.Contains(name))
                .Select(x => new HotelGetOutPutDto()
                {
                    HotelName = x.HotelName,
                    CityName = x.City.CityName
                }).ToListAsync(); 
        }
    }
}
