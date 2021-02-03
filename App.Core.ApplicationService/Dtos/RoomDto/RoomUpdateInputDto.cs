using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.RoomDto
{
    public class RoomUpdateInputDto
    {
        [Display(Name = "ای دی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Id { get; set; }


        [Display(Name = "کد اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RoomCode { get; set; }

        [Display(Name = "متراژ اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RoomAera { get; set; }

        [Display(Name = "قیمت اتاق")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int RoomPrice { get; set; }

        [Display(Name = "توضیحات")]
        public string Descripation { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HotelId { get; set; }


    }
}
