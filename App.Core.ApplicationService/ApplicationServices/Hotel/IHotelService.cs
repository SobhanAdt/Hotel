using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.Userto;
using Hotel.Core.ApplicationService.Dtos.HotelDto;

namespace App.Core.ApplicationService.ApplicationServices.Hotel
{
    public interface IHotelService
    {
        Task<string> Create(HotelInsertInputDto inputDto);

        Task<string> Update(HotelUpdateInputDto updateDto);

        List<HotelGetOutPutDto> GetAllHotels();

        List<HotelGetOutPutDto> GetTopHotelRate();

        Task<HotelGetOutPutDto> GetSingleHotel(int id);

        Task<string> DeleteHotels(int id);

        Task<List<HotelGetOutPutDto>> fourNewInsertHotel();

        Task<List<HotelGetOutPutDto>> HotelCompare(HotelCompareInputDto input);

        Task<FaivoriteHotel> FavoriteUser(HotelGetOutPutDto getOutPutDto);

    }
}
