namespace App.Core.ApplicationService.Dtos.ReviewDto
{
    public class ReviewAnswerDTO
    {
        public int Id { get; set; }

        public string CommentAnswer { get; set; }

        public int UserId { get; set; }

        public int ReviewId { get; set; }
    }
}