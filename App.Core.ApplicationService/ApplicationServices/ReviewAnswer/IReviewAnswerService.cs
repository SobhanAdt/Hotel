using App.Core.ApplicationService.Dtos.ReviewAnswerDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.ReviewAnswer
{
    public interface IReviewAnswerService
    {
        Task<string> Create(ReviewAnswerInsertInputDto inputDto,int userId);

        Task<string> Update(ReviewAnswerUpdateInputDto updateDto);

        Task<List<ReviewAnswerGetOutPutDto>> GetAllReviews();

        Task<ReviewAnswerGetOutPutDto> GetSingleReview(int id);

        Task<string> DeleteReview(int id);
    }
}
