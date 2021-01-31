using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.RoomDto
{
    public class RoomUpdateInputDto
    {
        [Required(ErrorMessage = "Please Enter Id")]
        public int Id { get; set; }       
        public int RoomCode { get; set; }
        public int RoomAera { get; set; }

        public int RoomPrice { get; set; }
        public string Descripation { get; set; }

        [Required(ErrorMessage = "Please Enter Hotel Id")]
        public int HotelId { get; set; }
    }
}
