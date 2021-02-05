using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.USerRateDto
{
    public class UserRateInsertDto
    {
        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public float RateNumber { get; set; }

        [Display(Name = "ای دی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int  UserId { get; set; }


        [Display(Name = "ای دی هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int  HotelId { get; set; }
    }
}
