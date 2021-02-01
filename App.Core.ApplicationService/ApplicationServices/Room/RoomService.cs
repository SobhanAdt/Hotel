using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.RoomDto;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.ApplicationService.ApplicationServices.Room
{
   public class RoomService:IRoomService
    {
        private IRepository<Entities.Room> repository;

        public RoomService(IRepository<Entities.Room> repository)
        {
            this.repository = repository;
        }

        public string Create(RoomInsertInputDto inputDto)
        {
            repository.Insert(new Entities.Room()
            {RoomCode=inputDto.RoomCode,
            RoomAera=inputDto.RoomAera,
            RoomPrice=inputDto.RoomPrice,
            Descripation=inputDto.Descripation,
            HotelId=inputDto.HotelId
            });
            repository.Save();
            return $" Room {inputDto.RoomCode} Created in DataBase";
        }

        public async Task<List<RoomGetOutPutDto>> GetAllRooms()
        {
            var lst =  repository.GetAll();
            return lst.Select(x => new RoomGetOutPutDto()
            {
                Id = x.Id,
                RoomCode = x.RoomCode,             
                RoomAera = x.RoomAera,
                RoomPrice = x.RoomPrice,
                Descripation = x.Descripation,
                HotelId = x.HotelId
            }).ToList();

        }

        public async Task<RoomGetOutPutDto> GetSingleRooms(int id)
        {
            var item =  repository.GetSingel(id);
            if (item == null)
            {
                return null;
            }

            return new RoomGetOutPutDto()
            {
                Id = item.Id,
                RoomCode = item.RoomCode,
                RoomAera = item.RoomAera,
                RoomPrice = item.RoomPrice,
                Descripation = item.Descripation,
                HotelId = item.HotelId
            };
        }

     

        public string Update(RoomUpdateInputDto updateDto)
        {

            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.RoomCode = updateDto.RoomCode;
            item.RoomAera = updateDto.RoomAera;
            item.RoomPrice = updateDto.RoomPrice;
            item.Descripation = updateDto.Descripation;
            item.HotelId = updateDto.HotelId;
            repository.Save();
            return $"Updating this Room{updateDto.RoomCode} has Successfuled";
        }


    }
}
