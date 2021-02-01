using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;

namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
   public interface IHotelService
    {
        string Create(HotelInsertInputDto inputDto);

        string Update(HotelUpdateInputDto updateDto);

        Task<List<HotelGetOutPutDto>> GetAllHotels();
        Task<HotelGetOutPutDto> GetSingleHotel(int id);

        string DeleteHotels(int id);

    }
}
