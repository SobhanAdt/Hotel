using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.HotelDto
{
  public class HotelGetOutPutDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public int HotelCode { get; set; }
        public int RoomCount { get; set; }
        public int CityId { get; set; }
        public int RateId { get; set; }
        public string Description { get; set; }


    }
}
