using App.Core.ApplicationService.Dtos.ReviewAnswerDto;
using App.Core.ApplicationService.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.ReviewAnswer
{
    public class ReviewAnswerService : IReviewAnswerService
    {
        private IRepository<Entities.ReviewAnswer> repository;
        public ReviewAnswerService(IRepository<Entities.ReviewAnswer> repository)
        {
            this.repository = repository;
        }

        public async Task<string> Create(ReviewAnswerInsertInputDto inputDto, int userId)
        {
            repository.Insert(new Entities.ReviewAnswer()
            {
                CommentAnswer = inputDto.CommentAnswer,
                ReviewId = inputDto.ReviewId,
                UserId = userId
            });
            await repository.Save();
            return $" {inputDto.CommentAnswer} Created in DataBase";
        }

        public async Task<string> DeleteReview(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<List<ReviewAnswerGetOutPutDto>> GetAllReviews()
        {
            var lst = await repository.GetQuery().ToListAsync();
            return lst.Select(x => new ReviewAnswerGetOutPutDto()
            {
                CommentAnswer = x.CommentAnswer,
                ReviewId = x.ReviewId,
                UserId = x.UserId,
                Id = x.Id
            }).ToList();
        }

        public async Task<ReviewAnswerGetOutPutDto> GetSingleReview(int id)
        {
            var item = await repository.GetQuery().Where(w => w.Id == id).FirstOrDefaultAsync();

            return new ReviewAnswerGetOutPutDto()
            {
                CommentAnswer = item.CommentAnswer,
                ReviewId = item.ReviewId,
                UserId = item.UserId
            };
        }

        public async Task<string> Update(ReviewAnswerUpdateInputDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.CommentAnswer = updateDto.CommentAnswer;
            item.UserId = updateDto.UserId;
            item.ReviewId = updateDto.ReviewId;
            await repository.Save();
            return $"Updating {updateDto.ReviewId} has Successfuled";
        }
    }
}

