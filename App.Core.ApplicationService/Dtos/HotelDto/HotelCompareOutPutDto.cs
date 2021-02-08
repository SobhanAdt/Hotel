using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Core.ApplicationService.Dtos.HotelDto
{
  public class HotelCompareOutPutDto
    {
        public string HotelName { get; set; }

        public int HotelCode { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public int StarId { get; set; }

    }

}
