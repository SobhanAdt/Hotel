using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hotel.Core.ApplicationService.Dtos.StarDto
{
    public class StarUpdateDto
    {
        public int Id { get; set; }


        [Display(Name = "شماره ستاره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int StarNumber { get; set; }
    }
}
