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

        public string Create(ReviewAnswerInsertInputDto inputDto)
        {
            repository.Insert(new Entities.ReviewAnswer()
            {
                CommentAnswer = inputDto.CommentAnswer,
                ReviewId = inputDto.ReviewId,
                UserId = inputDto.UserId
            });
            repository.Save();
            return $" {inputDto.CommentAnswer} Created in DataBase";
        }

        public string DeleteReview(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<List<ReviewAnswerGetOutPutDto>> GetAllReviews()
        {
            var lst = repository.GetQuery().Include(x => x.CommentAnswer);
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
            var item = repository.GetSingel(id);

            return new ReviewAnswerGetOutPutDto()
            {
                CommentAnswer = item.CommentAnswer,
                ReviewId = item.ReviewId,
                UserId = item.UserId
            };
        }

        public string Update(ReviewAnswerUpdateInputDto updateDto)
        {
            var item = repository.GetSingel(updateDto.ReviewId);
            if (item == null)
            {
                return "Null";
            }

            item.CommentAnswer = updateDto.CommentAnswer;
            item.ReviewId = updateDto.ReviewId;
            repository.Save();
            return $"Updating {updateDto.ReviewId} has Successfuled";
        }
    }
}

