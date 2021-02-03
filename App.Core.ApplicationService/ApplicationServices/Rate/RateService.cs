using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.RateDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.Rate
{
    public class RateService : IRateService
    {
        private IRepository<Entities.Rate> repository;

        public RateService(IRepository<Entities.Rate> repository)
        {
            this.repository = repository;
        }

        public async Task<List<RateOutputDto>> GetAllRate()
        {
            var lstItem = repository.GetQuery()
                .Include(x => x.Hotels).
                Select(x => new RateOutputDto()
                {
                    RateNumber = x.RateNumber,
                    Hotels = x.Hotels.Select(x => new HotelDTO()
                    {
                        CityId = x.CityId,
                        Description = x.Description,
                        HotelCode = x.HotelCode,
                        HotelName = x.HotelName,
                        RoomCount = x.RoomCount,
                        Id = x.Id,
                        RateId = x.RateId
                    }).ToList()
                }).ToList();
            return lstItem;
        }

        public async Task<RateOutputDto> GetSingelRate(int id)
        {
            var item = await repository.GetQuery().Include(x => x.Hotels).Where(x => x.Id == id).FirstOrDefaultAsync();
            return new RateOutputDto()
            {
                RateNumber = item.RateNumber,
                Hotels = item.Hotels.Select(x => new HotelDTO()
                {
                    RateId = x.RateId,
                    HotelCode = x.HotelCode,
                    RoomCount = x.RoomCount,
                    Description = x.Description,
                    CityId = x.CityId,
                    HotelName = x.HotelName,
                    Id = x.Id
                }).ToList()
            };
        }
    }
}