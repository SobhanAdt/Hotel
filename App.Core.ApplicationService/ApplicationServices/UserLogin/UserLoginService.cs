using System;
using System.Linq;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.UserLoginDto;
using App.Core.ApplicationService.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace App.Core.ApplicationService.ApplicationServices.UserLogin
{
    public class UserLoginService : IUserLoginService
    {
        private IRepository<Entities.User> userRepository;
        private IRepository<Entities.UserLogin> userloginRepository;

        public UserLoginService(IRepository<Entities.User> userRepository,
            IRepository<Entities.UserLogin> userloginRepository)
        {
            this.userRepository = userRepository;
            this.userloginRepository = userloginRepository;
        }


        public async Task<string> CreateToken(LoginDto login)
        {
            var UserLogin =userRepository.GetQuery()
                .SingleOrDefault(s => s.Email == login.Email && s.Password == login.Password);


            if (UserLogin != null)
            {
                var token = Guid.NewGuid().ToString();
                userloginRepository.Insert(new Entities.UserLogin()
                {
                    UserId = UserLogin.Id,
                    Token = token,
                    ExpDate = DateTime.Now.AddHours(24)
                });
                await userloginRepository.Save();
                return token;

            }

            return null;
        }

        //public async Task<Entities.User> LoginUser(LoginDto login)
        //{
        //    var user = await userRepository.GetQuery().
        //         SingleOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

        //    return user;
        //}

        public async Task<int> ValidateUser(string Token)
        {
            var userToken = await userloginRepository.GetQuery()
                    .Where(x => x.Token == Token).FirstOrDefaultAsync();

            if (userToken != null)
            {
                if (userToken.ExpDate < DateTime.Now)
                {
                    return 0;
                }
            }

            return userToken.UserId;
        }
    }
}