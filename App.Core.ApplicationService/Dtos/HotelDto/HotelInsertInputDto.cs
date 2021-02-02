using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.HotelDto
{
  public class HotelInsertInputDto
    {
        [Display(Name = "نام هتل")]
        [Required(ErrorMessage = "نام هتل حتما باید وارد شود")]
        public string HotelName { get; set; }      
        public int HotelCode { get; set; }
        public int RoomCount { get; set; }
        public string Description { get; set; }

        public int CityId { get; set; }
        public int RateId { get; set; }

    }
}
