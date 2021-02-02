using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
   public class ReviewInsertInputDto
    {
        [Display(Name = "نظر خود را وارد کنید")]
        [Required(ErrorMessage = "نام کاربری را وادر کنید")]
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int HotelId { get; set; }

    }
}
