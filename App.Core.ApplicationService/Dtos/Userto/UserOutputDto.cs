using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.ReviewDto;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.Userto
{
    public class UserOutputDto
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }


        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نمی باشد")]
        public string Email { get; set; }


        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }


        [Display(Name = "لیست نطرات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<ReviewDTO> Reviews { get; set; }


        [Display(Name = "لیست جواب نظرات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public List<ReviewAnswerDTO> ReviewAnswers { get; set; }

    }
}