using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
    class ReviewGetOutPutDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
    }
}
