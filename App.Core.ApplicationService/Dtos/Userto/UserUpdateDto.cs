using System.ComponentModel.DataAnnotations;

namespace App.Core.ApplicationService.Dtos.Userto
{
    public class UserUpdateDto
    {
        public int Id { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
    }
}