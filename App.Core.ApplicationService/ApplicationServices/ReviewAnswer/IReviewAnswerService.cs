using App.Core.ApplicationService.Dtos.ReviewAnswerDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.ReviewAnswer
{
    public interface IReviewAnswerService
    {
        string Create(ReviewAnswerInsertInputDto inputDto);

        string Update(ReviewAnswerUpdateInputDto updateDto);

        Task<List<ReviewAnswerGetOutPutDto>> GetAllReviews();
        Task<ReviewAnswerGetOutPutDto> GetSingleReview(int id);

        string DeleteReview(int id);
    }
}
