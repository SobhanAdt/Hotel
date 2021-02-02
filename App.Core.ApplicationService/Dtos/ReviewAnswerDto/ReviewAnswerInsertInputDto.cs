using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewAnswerDto
{
    public class ReviewAnswerInsertInputDto
    {
        [Display(Name = "نظر خود را وارد کنید")]
        [Required(ErrorMessage = "نام کاربری را وادر کنید")]
        public string CommentAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }
    }
}
