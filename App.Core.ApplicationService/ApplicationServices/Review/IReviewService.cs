using App.Core.ApplicationService.Dtos.ReviewDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.Review
{
    public interface IReviewService
    {
        Task<string> Create(ReviewInsertInputDto inputDto);

        Task<string> Update( ReviewUpdateInputDto updateDto);

        Task<List<ReviewGetOutPutDto>> GetAllReviews();
        Task<ReviewGetOutPutDto> GetSingleReview(int id);

        Task<string> DeleteReview(int id);
    }
}
