using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
   public class ReviewInsertInputDto
    {
        [Display(Name = "نظر")]
        [Required(ErrorMessage = "نام کاربری را وادر کنید")]
        public string Comment { get; set; }


        [Display(Name = "ای دی هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HotelId { get; set; }

    }
}
