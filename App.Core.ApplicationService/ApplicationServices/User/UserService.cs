using App.Core.ApplicationService.Dtos.Userto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.HotelDto;
using App.Core.ApplicationService.Dtos.ReviewDto;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.User
{
    public class UserService : IUserService
    {
        private IRepository<Entities.User> repository;

        public UserService(IRepository<Entities.User> repository)
        {
            this.repository = repository;

        }

        public async Task<string> DeleteUser(int id)
        {
            await repository.Delete(id);
            await repository.Save();
            return "Delete Anjam Shod";
        }

        public async Task<List<UserOutputDto>> GetAllUser()
        {
            var lst = repository.GetQuery().
                Include(x => x.Reviews)
                .Include(x => x.ReviewAnswers)
                .Include(x => x.UserLogins);

            return lst.Select(x => new UserOutputDto()
            {
                Email = x.Email,
                FullName = x.FullName,
                Password = x.Password,
                Reviews = x.Reviews.Select(x => new ReviewDTO()
                {
                    Comment = x.Comment,
                    Id = x.Id
                }).ToList(),
                ReviewAnswers = x.ReviewAnswers.Select(x => new ReviewAnswerDTO()
                {
                    ReviewId = x.ReviewId,
                    Id = x.Id,
                    CommentAnswer = x.CommentAnswer
                }).ToList()
            }).ToList();
        }

        public async Task<UserOutputDto> GetSingelUser(int id)
        {
            var singleUser = await repository.GetQuery().Include(x => x.Reviews)
                    .Include(y => y.ReviewAnswers).Where(z => z.Id == id).FirstOrDefaultAsync();

            return new UserOutputDto()
            {
                FullName = singleUser.FullName,
                Email = singleUser.Email,
                Password = singleUser.Password,
                Reviews = singleUser.Reviews.Select(x => new ReviewDTO()
                {
                    Comment = x.Comment,
                    Id = x.Id
                }).ToList(),
                ReviewAnswers = singleUser.ReviewAnswers.Select(x => new ReviewAnswerDTO()
                {
                    ReviewId = x.ReviewId,
                    Id = x.Id,
                    CommentAnswer = x.CommentAnswer
                }).ToList()
            };
        }

        public async Task<string> InsertUser(UserInsertInputDto insertInputDto)
        {
            repository.Insert(new Entities.User()
            {
                Email = insertInputDto.Email,
                FullName = insertInputDto.FullName,
                Password = insertInputDto.Password
            });
            await repository.Save();
            return $"Useri be Name : {insertInputDto.FullName} Ezafe Shod";
        }

        public async Task<string> UpdateUser(UserUpdateDto updateDto)
        {
            var item = repository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return null;
            }

            item.Email = updateDto.Email;
            item.FullName = updateDto.FullName;
            item.Password = updateDto.Password;
            await repository.Save();
            return $"Update Ba Mofaghiyat Anjam Shod";

        }
    }
}
