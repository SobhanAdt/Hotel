using System.ComponentModel.DataAnnotations;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityInsertInputDto
    {
        [Required(ErrorMessage = "نام شهر باید وارد شود")]
        public string CityName { get; set; }
    }
}