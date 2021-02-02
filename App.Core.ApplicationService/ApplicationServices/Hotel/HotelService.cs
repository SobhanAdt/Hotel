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
        private IRepository<Entities.Room> roomRepository;
        private static int CurrentCode = 1000;

        public HotelService(IRepository<Entities.Hotel> repository, IRepository<Entities.Room> roomRepository)
        {
            this.repository = repository;
            this.roomRepository = roomRepository;
        }

        public string Create(HotelInsertInputDto inputDto)
        {
            repository.Insert(new Entities.Hotel()
            {
                HotelName = inputDto.HotelName,
                HotelCode = inputDto.HotelCode,
                CityId = inputDto.CityId,
                RoomCount = inputDto.RoomCount,
                RateId = inputDto.RateId,
                Description = inputDto.Description
            });
            repository.Save();
            return $" {inputDto.HotelName} Created in DataBase";
        }

        public async Task<List<HotelGetOutPutDto>> GetAllHotels()
        {
            var lst =  repository.GetQuery().Include(x=>x.Rooms);
            return lst.Select(x => new HotelGetOutPutDto()
            {
                HotelName = x.HotelName,
                Id = x.Id,
                HotelCode = x.HotelCode,
                RoomCount = x.RoomCount,
                Description = x.Description,
                RateId = x.RateId,
                CityId = x.CityId,
                Rooms = x.Rooms
            }).ToList();

        }

        public async Task<HotelGetOutPutDto> GetSingleHotel(int id)
        {
            var item =  repository.GetSingel(id);
            var ListSingle = roomRepository.GetQuery().Where(x => x.HotelId == id).ToList();
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
                Description = item.Description,
                Rooms = item.Rooms
            };
        }

        public string DeleteHotels(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "Delete Anjam shod";
        }

        public string Update(int id,HotelUpdateInputDto updateDto)
        {

            var item = repository.GetSingel(id);
            if (item == null)
            {
                return "Null";
            }

            item.HotelName = updateDto.HotelName;
            item.CityId = updateDto.CityId;
            item.RateId = updateDto.RateId;
            item.RoomCount = updateDto.RoomCount;
            repository.Save();
            return $"Updating {updateDto.HotelName} has Successfuled";
        }




    }
}
