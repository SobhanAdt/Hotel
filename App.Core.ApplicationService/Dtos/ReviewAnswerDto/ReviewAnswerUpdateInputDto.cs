using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewAnswerDto
{
    public class ReviewAnswerUpdateInputDto
    {
        [Required(ErrorMessage = "Please Enter Review Id")]
        public string CommentAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }
    }
}
