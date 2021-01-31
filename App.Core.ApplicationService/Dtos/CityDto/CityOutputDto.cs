using System.ComponentModel.DataAnnotations;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityOutputDto
    {
        public int Id { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "نام شهر حتما باید وارد شود")]
        public string Name { get; set; }
    }
}