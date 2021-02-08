using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using Hotel.Core.ApplicationService.Dtos.HotelDto;

namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
    public interface IHotelService
    {
        Task<string> Create(HotelInsertInputDto inputDto);

        Task<string> Update(HotelUpdateInputDto updateDto);

        Task<List<HotelGetOutPutDto>> GetAllHotels();
        Task<HotelGetOutPutDto> GetSingleHotel(int id);

        Task<string> DeleteHotels(int id);

        Task<List<HotelGetOutPutDto>> SixNewInsertHotel();

      List<HotelGetOutPutDto> HotelCompare(HotelCompareInputDto input);
 
    }
}
