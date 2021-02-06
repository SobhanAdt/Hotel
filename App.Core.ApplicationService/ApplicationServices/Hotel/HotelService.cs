using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;


namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
    public class HotelService : IHotelService

    {
        private IRepository<Entities.Hotel> repository;


        public HotelService(IRepository<Entities.Hotel> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Create(HotelInsertInputDto inputDto)
        {
            var hotelValidation =await repository.GetQuery().
                Where(x => x.HotelName == inputDto.HotelName&&x.CityId==inputDto.CityId)
                .FirstOrDefaultAsync();

            if (inputDto.HotelCode==hotelValidation.HotelCode)
            {
                return null;
            }

            repository.Insert(new Entities.Hotel()
            {
                HotelName = inputDto.HotelName,
                HotelCode = inputDto.HotelCode,
                CityId = inputDto.CityId,
                RoomCount = inputDto.RoomCount,
                StarId = inputDto.StarId,
                Description = inputDto.Description
            });
            await repository.Save();
            return $" {inputDto.HotelName} Created in DataBase";
        }

        public Task<List<HotelGetOutPutDto>> GetAllHotels()
        {
            var lst = repository.GetQuery().Include(x => x.Rooms);
            return lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                StarId = x.StarId,
                CityId = x.CityId,
                Rooms = x.Rooms.Select(x => new RoomDTO()
                {
                    Descripation = x.Descripation,
                    RoomAera = x.RoomAera,
                    RoomCode = x.RoomCode,
                    Id = x.Id,
                    RoomPrice = x.RoomPrice
                }).ToList(),
                Reviews = x.Reviews.Select(x => new ReviewDTO()
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    Comment = x.Comment
                }).ToList()
            }).ToListAsync();

        }

        public async Task<HotelGetOutPutDto> GetSingleHotel(int id)
        {
            var item = await repository.GetQuery()
                .Include(x => x.Rooms).Where(x => x.Id == id)
                .Include(x => x.Reviews).Where(x => x.Id == id).FirstOrDefaultAsync();

            return new HotelGetOutPutDto()
            {
                Id = item.Id,
                HotelName = item.HotelName,
                HotelCode = item.HotelCode,
                RoomCount = item.RoomCount,
                CityId = item.CityId,
                StarId = item.StarId,
                Description = item.Description,
                Rooms = item.Rooms.Select(x => new RoomDTO()
                {
                    Descripation = x.Descripation,
                    RoomAera = x.RoomAera,
                    RoomCode = x.RoomCode,
                    Id = x.Id,
                    RoomPrice = x.RoomPrice
                }).ToList(),
                Reviews = item.Reviews.Select(x => new ReviewDTO()
                {
                    UserId = x.UserId,
                    Id = x.Id,
                    Comment = x.Comment
                }).ToList()
            };
        }

        public async Task<string> DeleteHotels(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<string> Update(HotelUpdateInputDto updateDto)
        {

            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.HotelName = updateDto.HotelName;
            item.CityId = updateDto.CityId;
            item.StarId = updateDto.StarId;
            item.RoomCount = updateDto.RoomCount;
            await repository.Save();
            return $"Updating {updateDto.HotelName} has Successfuled";
        }




    }
}
