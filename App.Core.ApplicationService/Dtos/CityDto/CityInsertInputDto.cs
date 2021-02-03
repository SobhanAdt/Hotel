using System.ComponentModel.DataAnnotations;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityInsertInputDto
    {
        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CityName { get; set; }
    }
}