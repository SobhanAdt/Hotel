using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
    public class ReviewUpdateInputDto
    {
        [Required(ErrorMessage = "Please Enter Review Id")]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }
    }
}
