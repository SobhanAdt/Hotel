using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.HotelDto
{
  public class HotelInsertInputDto
    {
        [Display(Name = "نام هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string HotelName { get; set; }

        [Display(Name = "کد هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HotelCode { get; set; }

        [Display(Name = "تعداد اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RoomCount { get; set; }

        [Display(Name = "توضیحات هتل")]
        public string Description { get; set; }

        [Display(Name = "ای دی شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CityId { get; set; }

        [Display(Name = "ای دی ستاره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int StarId { get; set; }

    }
}
