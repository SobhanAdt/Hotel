using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using App.Core.ApplicationService.IRepositories;

namespace App.Core.Entities
{
    public class City : IHasIdentity
    {
        public int Id { get; set; }

        [Display(Name = "نام شهر")]
        [Required(ErrorMessage = "نام شهر را باید وارد کنید")]
        public string CityName { get; set; }
    }
}
