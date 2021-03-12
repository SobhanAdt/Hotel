using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.StarDto;
using App.Core.ApplicationService.IRepositories;
using AutoMapper;
using Hotel.Core.ApplicationService.Dtos.StarDto;
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

        public  Task<List<StarOutputDto>> GetAllStar()
        {
            var lstItem = repository.GetQuery().Include(x => x.Hotels);


            var ListStar =  lstItem.Select(x => new StarOutputDto()
            {
                Id = x.Id,
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
            }).ToListAsync();
            return ListStar;
        }

        public async Task<StarOutputDto> GetSingelStar(int id)
        {
            var item = await repository.GetQuery().
                Include(x => x.Hotels).
                Where(x => x.Id == id).FirstOrDefaultAsync();
            return new StarOutputDto()
            {
                Id = item.Id,
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

        public async Task<string> UpdateStar(StarUpdateDto updateDto)
        {
            var item = GetSingelStar(updateDto.Id);
            if (item ==null)
            {
                return "null";
            }

            item.Result.StarNumber = updateDto.StarNumber;
            await repository.Save();
            return "Done Update";
        }
    }
}