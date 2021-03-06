﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewAnswerDto
{
    public class ReviewAnswerInsertInputDto
    {
        [Display(Name = "جواب نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CommentAnswer { get; set; }


        [Display(Name = "ای دی نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ReviewId { get; set; }
    }
}
