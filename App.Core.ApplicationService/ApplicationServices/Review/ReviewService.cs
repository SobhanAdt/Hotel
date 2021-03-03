using App.Core.ApplicationService.Dtos.ReviewDto;
using App.Core.ApplicationService.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ApplicationService.ApplicationServices.Review
{
    public class ReviewService : IReviewService
    {
        private IRepository<Entities.Review> repository;
        public ReviewService(IRepository<Entities.Review> repository)
        {
            this.repository = repository;
        }
        public async Task<string> Create(ReviewInsertInputDto inputDto,int userId)
        {
            repository.Insert(new Entities.Review()
            {
                Comment = inputDto.Comment,
                HotelId = inputDto.HotelId,
                UserId = userId
            });
            await repository.Save();
            return $" {inputDto.Comment} Created in DataBase";
        }

        public async Task<string> DeleteReview(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<List<ReviewGetOutPutDto>> GetAllReviews()
        {
            var lst = repository.GetQuery()
                .Include(i=>i.User)
                .Include(x => x.ReviewAnswers);
            return await lst.Select(x => new ReviewGetOutPutDto()
            {
                Comment = x.Comment,
                HotelId = x.HotelId,
                UserId = x.UserId,
                Id = x.Id,
                UserName = x.User.FullName,
                ReviewAnswers = x.ReviewAnswers.Select(x => new ReviewAnswerDTO()
                {
                    CommentAnswer = x.CommentAnswer,
                    Id = x.Id,
                    UserId = x.UserId
                }).ToList()

            }).ToListAsync();
        }

        public async Task<ReviewGetOutPutDto> GetSingleReview(int id)
        {
            var item = await repository.GetQuery().Include(x => x.ReviewAnswers).Where(x => x.Id == id).FirstOrDefaultAsync();

            return new ReviewGetOutPutDto()
            {
                Id = item.Id,
                Comment = item.Comment,
                UserId = item.UserId,
                HotelId = item.HotelId,
                ReviewAnswers = item.ReviewAnswers.Select(x => new ReviewAnswerDTO()
                {
                    CommentAnswer = x.CommentAnswer,
                    Id = x.Id,
                    UserId = x.UserId
                }).ToList()
            };
        }

        public async Task<string> Update(ReviewUpdateInputDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return "Null";
            }

            item.Comment = updateDto.Comment;
            item.HotelId = updateDto.HotelId;
            await repository.Save();
            return $"Updating {updateDto.Id} has Successfuled";
        }
    }
}
