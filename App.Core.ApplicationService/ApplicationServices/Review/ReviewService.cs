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
        public string Create(ReviewInsertInputDto inputDto)
        {
            repository.Insert(new Entities.Review()
            {
                Comment = inputDto.Comment,
                UserId = inputDto.UserId,
                HotelId = inputDto.HotelId
            }) ;
            repository.Save();
            return $" {inputDto.Comment} Created in DataBase";
        }

        public string DeleteReview(int id)
        {
            repository.Delete(id);
            repository.Save();
            return "Delete Anjam shod";
        }

        public async Task<List<ReviewGetOutPutDto>> GetAllReviews()
        {
            var lst = repository.GetQuery().Include(x => x.Comment);
            return lst.Select(x => new ReviewGetOutPutDto()
            {
                Comment = x.Comment,
                HotelId = x.HotelId,
                UserId = x.UserId,
                Id = x.Id
            }).ToList();
        }

        public async Task<ReviewGetOutPutDto> GetSingleReview(int id)
        {
            var item = repository.GetSingel(id);

            return new ReviewGetOutPutDto()
            {
                Id = item.Id,
                Comment = item.Comment,
                UserId = item.UserId,
                HotelId = item.HotelId
            };
        }

        public string Update(int id, ReviewUpdateInputDto updateDto)
        {
            var item = repository.GetSingel(id);
            if (item == null)
            {
                return "Null";
            }

            item.Comment = updateDto.Comment;
            item.HotelId = updateDto.HotelId;
            repository.Save();
            return $"Updating {updateDto.Id} has Successfuled";
        }
    }
}
