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


        public async Task<string> Login(LoginDto login)
        {
            var UserLogin = await userRepository.GetQuery().
                Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefaultAsync();

            if (UserLogin != null)
            {
                var token = Guid.NewGuid().ToString();
                userloginRepository.Insert(new Entities.UserLogin()
                {
                    UserId = UserLogin.Id,
                    Token = token,
                    ExpDate = DateTime.Now.AddHours(24)
                });

                return token;
            }

            return "Error";
        }

        public async Task<int> ValidateUser(string Token)
        {
            try
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
            catch
            {
                throw new Exception("Token Na Motabar Ast");
            }

        }
    }
}