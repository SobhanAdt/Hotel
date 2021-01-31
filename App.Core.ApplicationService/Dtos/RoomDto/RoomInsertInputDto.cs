using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.RoomDto
{
    public class RoomInsertInputDto
    {
        [Required]
        public int RoomCode { get; set; }
        [Required]
        public int RoomAera { get; set; }
        [Required]
        public int RoomPrice { get; set; }      
        public string Descripation { get; set; }
      
        [Required(ErrorMessage = "Please Enter Hotel Id")]
        public int HotelId { get; set; }
    }
}
