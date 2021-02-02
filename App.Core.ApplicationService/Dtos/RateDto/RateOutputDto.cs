using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.RateDto
{
    public class RateOutputDto
    {

        [Display(Name = "ستاره هتل")]
        [Required(ErrorMessage = "باید {0} را وارد کنید")]
        public int RateNumber { get; set; }


        [Display(Name = "هتل ها")]
        [Required(ErrorMessage = "باید {0} را وارد کنید")]
        public List<Hotel> Hotels { get; set; }
    }
}