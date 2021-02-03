using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewDto
{
    public class ReviewUpdateInputDto
    {
        [Display(Name = "ای دی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Id { get; set; }


        [Display(Name = "نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Comment { get; set; }

        [Display(Name = "ای دی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }

        [Display(Name = "ای دی هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HotelId { get; set; }
    }
}
