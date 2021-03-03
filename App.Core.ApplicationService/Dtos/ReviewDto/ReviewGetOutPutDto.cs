using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
   public class ReviewGetOutPutDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }

        public string UserName { get; set; }

        public List<ReviewAnswerDTO> ReviewAnswers { get; set; }
    }
}
