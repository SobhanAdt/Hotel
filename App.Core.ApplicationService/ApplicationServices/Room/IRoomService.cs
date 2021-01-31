using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.RoomDto;

namespace App.Core.ApplicationService.ApplicationServices.Room
{
   public interface IRoomService
    {
        string Create(RoomInsertInputDto inputDto);

        string Update(RoomUpdateInputDto updateDto);

        Task<List<RoomGetOutPutDto>> GetAllRooms();
        Task<RoomGetOutPutDto> GetSingleRooms(int id);
    }
}
