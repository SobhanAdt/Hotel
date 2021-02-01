using App.Core.ApplicationService.Dtos.Userto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.IRepositories;
using App.Core.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.User
{
    public class UserService : IUserService
    {
        private IRepository<Entities.User> userRepository;
        private IRepository<Review> reviewRepository;
        private IRepository<ReviewAnswer> reviewAnsweRepository;
        private IRepository<UserLogin> userLoginRepository;

        public UserService(IRepository<Entities.User> userRepository
            , IRepository<Review> reviewRepository
            , IRepository<ReviewAnswer> reviewAnsweRepository
            , IRepository<UserLogin> userLoginRepository)
        {
            this.userRepository = userRepository;
            this.reviewRepository = reviewRepository;
            this.reviewAnsweRepository = reviewAnsweRepository;
            this.userLoginRepository = userLoginRepository;
        }

        public string DeleteUser(int id)
        {
            userRepository.Delete(id);
            userRepository.Save();
            return "Delete Anjam Shod";
        }

        public async Task<List<UserOutputDto>> GetAllUser()
        {
            var lst = userRepository.GetQuery().Include(x => x.Reviews).Include(x => x.ReviewAnswers)
                .Include(x => x.UserLogins);

            return lst.Select(x => new UserOutputDto()
            {
                Reviews = x.Reviews,
                Email = x.Email,
                FullName = x.FullName,
                ReviewAnswers = x.ReviewAnswers,
                Password = x.Password,
                UserLogins = x.UserLogins
            }).ToList();
        }

        public async Task<UserOutputDto> GetSingelUser(int id)
        {
            var singleUser = userRepository.GetSingel(id);
            var lstReview = reviewRepository.GetQuery().Where(x => x.UserId == id).ToList();
            var lstReviewAnswer = reviewAnsweRepository.GetQuery().Where(x => x.UserId == id).ToList();
            var lstUserLogin = userLoginRepository.GetQuery().Where(x => x.UserId == id).ToList();

            return new UserOutputDto()
            {
                FullName = singleUser.FullName,
                Email = singleUser.Email,
                Password = singleUser.Password,
                Reviews = lstReview,
                ReviewAnswers = lstReviewAnswer,
                UserLogins = lstUserLogin
            };
        }

        public string InsertUser(UserInsertInputDto insertInputDto)
        {
            userRepository.Insert(new Entities.User()
            {
                Email = insertInputDto.Email,
                FullName = insertInputDto.FullName,
                Password = insertInputDto.Password
            });
            userRepository.Save();
            return $"Useri be Name : {insertInputDto.FullName} Ezafe Shod";
        }

        public string UpdateUser(UserUpdateDto updateDto)
        {
            var item = userRepository.GetSingel(updateDto.Id);
            if (item == null)
            {
                return null;
            }

            item.Email = updateDto.Email;
            item.FullName = updateDto.FullName;
            item.Password = updateDto.Password;
            userRepository.Save();
            return $"Update Ba Mofaghiyat Anjam Shod";

        }
    }
}
