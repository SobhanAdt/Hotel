using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.RoomDto
{
   public class RoomGetOutPutDto
    {
        public int Id { get; set; }

        public int RoomCode { get; set; }

        public int RoomAera { get; set; }

        public int RoomPrice { get; set; }

        public string Descripation { get; set; }

        public int HotelId { get; set; }
    }
}
