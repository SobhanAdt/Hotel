using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.IRepositories;
using System.Linq;




namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
   public class HotelService : IHotelService

    {
        private IRepository<Entities.Hotel> repository;

        public HotelService(IRepository<Entities.Hotel> repository)
        {
            this.repository = repository;
        }

        public string Create(HotelInsertInputDto inputDto)
        {
            repository.Insert(new Entities.Hotel()
            {
                HotelName = inputDto.HotelName,
                HotelCode = inputDto.HotelCode,
                CityId = inputDto.CityId,
                RoomCount = inputDto.RoomCount,
                RateId = inputDto.RateId
            });
            repository.Save();
            return $" {inputDto.HotelName} Created in DataBase";
        }

        public async Task<List<HotelGetOutPutDto>> GetAllHotels()
        {
            var lst = await repository.GetAll();
            return lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                RateId = x.RateId,
                CityId = x.CityId
            }).ToList();

        }

        public async Task<HotelGetOutPutDto> GetSingleHotel(int id)
        {
            var item = await repository.GetSingel(id);
            if (item == null)
            {
                return null;
            }

            return new HotelGetOutPutDto()
            {
                Id = item.Id,
                HotelName = item.HotelName,
                HotelCode = item.HotelCode,
                RoomCount = item.RoomCount,
                CityId = item.CityId,
                RateId = item.RateId,
                Description = item.Description
            };
        }

        public string Update(HotelUpdateInputDto updateDto)
        {

            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.Result.HotelName = updateDto.HotelName;
            item.Result.CityId = updateDto.CityId;
            item.Result.RateId = updateDto.RateId;
            item.Result.RoomCount = updateDto.RoomCount;
            repository.Save();
            return $"Updating {updateDto.HotelName} has Successfuled";
        }




    }
}
