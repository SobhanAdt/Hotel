using System;
using System.Collections.Generic;
using System.Text;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.StarDto;

namespace Hotel.Core.ApplicationService.Dtos.IndexDto
{
    public class IndexGetoutDto
    {
        public List<HotelGetOutPutDto> TopHotel { get; set; }

        public List<HotelGetOutPutDto> NewHotel { get; set; }

        public List<CityOutputDto> CityList { get; set; }

        public List<StarOutputDto> StarList { get; set; }
    }
}
