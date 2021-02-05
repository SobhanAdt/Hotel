using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.ApplicationService.Dtos.CityDto;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.StarDto
{
    public class StarOutputDto
    {

        public int StarNumber { get; set; }


        public List<HotelDTO> Hotels { get; set; }
    }
}