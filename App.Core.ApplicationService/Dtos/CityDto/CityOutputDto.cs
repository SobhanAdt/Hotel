using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityOutputDto
    {
        public int Id { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "نام {0} حتما باید وارد شود")]
        public string CityName { get; set; }

        [Display(Name = "لیست هتل ها")]
        [Required(ErrorMessage = "نام {0} حتما باید وارد شود")]
        public List<Hotel> Hotels { get; set; }
    }
}