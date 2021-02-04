using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.RoomDto;

namespace App.Core.ApplicationService.ApplicationServices.Room
{
   public interface IRoomService
    {
        Task<string> Create(RoomInsertInputDto inputDto);

        Task<string> Update(RoomUpdateInputDto updateDto);

        Task<List<RoomGetOutPutDto>> GetAllRooms();
        Task<RoomGetOutPutDto> GetSingleRooms(int id);

        Task<string> DeleteRooms(int id);
    }
}
