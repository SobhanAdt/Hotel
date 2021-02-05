using System.ComponentModel.DataAnnotations;

namespace App.Core.ApplicationService.Dtos.USerRateDto
{
    public class UserRateUpdateDto
    {
        [Display(Name = "ای دی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Id { get; set; }

        [Display(Name = "امتیاز")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public float RateNumber { get; set; }

        [Display(Name = "ای دی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }


        [Display(Name = "ای دی هتل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HotelId { get; set; }
    }
}