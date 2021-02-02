using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityOutputDto
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public  List<HotelDTO> Hotels { get; set; }

    }

    public class HotelDTO
    {
        public int Id { get; set; }

        public string HotelName { get; set; }

        public int HotelCode { get; set; }

        public int RoomCount { get; set; }

        public string Description { get; set; }

        public int CityId { get; set; }

        public int RateId { get; set; }

    }
}