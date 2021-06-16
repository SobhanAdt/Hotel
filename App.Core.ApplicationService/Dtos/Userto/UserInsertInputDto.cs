using System.ComponentModel.DataAnnotations;
using System.Data;

namespace App.Core.ApplicationService.Dtos.Userto
{
    public class UserInsertInputDto
    {
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FullName { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل صحیح نمی باشد")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("Password", ErrorMessage = "رمز ها با هم مغایرت دارند لطفا توجه فرمائید!")]
        public string ReplayPassword { get; set; }
    }
}