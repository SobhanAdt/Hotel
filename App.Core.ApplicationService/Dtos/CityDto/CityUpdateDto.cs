using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.Core.Entities;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityUpdateDto
    {
        [Display(Name = "ای دی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Id { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CityName { get; set; }

    }
}
