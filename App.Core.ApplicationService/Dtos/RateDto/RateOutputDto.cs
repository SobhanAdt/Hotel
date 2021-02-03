using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.RateDto
{
    public class RateOutputDto
    {

        public int RateNumber { get; set; }


        public List<HotelDTO> Hotels { get; set; }
    }
}