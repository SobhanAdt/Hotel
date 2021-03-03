using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;

namespace Hotel.Core.ApplicationService.ApplicationServices.Hotel
{
   public interface IHotelSearchService
    {
        public Task<List<HotelGetOutPutDto>> SearchByHotelName(string name);
    }
}
