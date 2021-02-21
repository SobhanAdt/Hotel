using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.StarDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.Rate
{
    public class StarService : IStarService
    {
        private IRepository<Entities.Star> repository;

        public StarService(IRepository<Entities.Star> repository)
        {
            this.repository = repository;
        }

        public  List<StarOutputDto> GetAllRate()
        {
            var lstItem = repository.GetQuery()
                .Include(x => x.Hotels).
                Select(x => new StarOutputDto()
                {
                    StarNumber = x.StarNumber,
                    Hotels = x.Hotels.Select(x => new HotelDTO()
                    {
                        CityId = x.CityId,
                        Description = x.Description,
                        HotelCode = x.HotelCode,
                        HotelName = x.HotelName,
                        RoomCount = x.RoomCount,
                        Id = x.Id,
                        StarId = x.StarId
                    }).ToList()
                }).ToList();
            return lstItem;
        }

        public async Task<StarOutputDto> GetSingelRate(int id)
        {
            var item = await repository.GetQuery().Include(x => x.Hotels).Where(x => x.Id == id).FirstOrDefaultAsync();
            return new StarOutputDto()
            {
                StarNumber = item.StarNumber,
                Hotels = item.Hotels.Select(x => new HotelDTO()
                {
                    StarId = x.StarId,
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