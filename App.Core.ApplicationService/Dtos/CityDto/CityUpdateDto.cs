using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.CityDto
{
    public class CityUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage="نام شهر را وراد کنید")]
        public string CityName { get; set; }
    }
}
