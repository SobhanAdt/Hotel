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
        public HotelSearchService(IRepository<App.Core.Entities.Hotel> repository,
           IRepository<App.Core.Entities.UserRate> userRateRepository )
        {
            this.repository = repository;
            this.userRateRepository = userRateRepository;
        }
        public async Task<List<HotelGetOutPutDto>> SearchByHotelName(string name)
        {
            var lst = repository.GetQuery().Where(x => x.HotelName.Contains(name))
            .Include(x => x.Reviews);

            var userRate = userRateRepository.GetQuery().
                Where(w => w.HotelId == w.Hotel.Id)
                .GroupBy(x => x.HotelId).Select(x => new HotelGetOutPutDto()
                {
                    Id = x.Key,
                    Rate = x.Average(x => x.RateNumber)
                }).ToList();


            var ListHotelId = userRate.Select(x => x.Id).ToList();

            var ListHotel = await lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                CityName = x.City.CityName,
                Reviews = x.Reviews.Select(y => new ReviewDTO()
                {
                    UserId = y.UserId,
                    Id = y.Id,
                    Comment = y.Comment
                }).ToList()
            }).ToListAsync();

            foreach (var item in ListHotel)
            {

                if (ListHotelId.Contains(item.Id))
                {
                    item.Rate = userRate.Where(x => x.Id == item.Id).FirstOrDefault().Rate;
                }
            }


            return ListHotel;
        }
    }
}
