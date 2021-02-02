﻿using App.Core.ApplicationService.Dtos.ReviewDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.Review
{
    public interface IReviewService
    {
        string Create(ReviewInsertInputDto inputDto);

        string Update( ReviewUpdateInputDto updateDto);

        Task<List<ReviewGetOutPutDto>> GetAllReviews();
        Task<ReviewGetOutPutDto> GetSingleReview(int id);

        string DeleteReview(int id);
    }
}