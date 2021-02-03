using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewAnswerDto
{
    public class ReviewAnswerUpdateInputDto
    {
        [Display(Name = "ای دی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Id { get; set; }


        [Display(Name = "جواب نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentAnswer { get; set; }


        [Display(Name = "ای دی کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }


        [Display(Name = "ای دی نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ReviewId { get; set; }
    }
}
