using System;
using System.Collections.Generic;
using System.Text;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.HotelDto
{
  public class HotelGetOutPutDto
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public int HotelCode { get; set; }
        public int RoomCount { get; set; }
        public int CityId { get; set; }
        public int StarId { get; set; }

        public RateDTO Rate { get; set; }

        public string Description { get; set; }

        public List<ReviewDTO> Reviews { get; set; }


    }
}
