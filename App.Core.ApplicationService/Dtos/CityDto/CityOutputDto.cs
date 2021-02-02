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

        public  List<Hotel> Hotels { get; set; }

    }
}