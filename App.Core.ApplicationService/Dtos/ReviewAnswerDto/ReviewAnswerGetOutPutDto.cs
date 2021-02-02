using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.ApplicationService.Dtos.ReviewAnswerDto
{
    public class ReviewAnswerGetOutPutDto
    {
        public int Id { get; set; }

        public string CommentAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }
    }
}
