using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.UserLoginDto;

namespace App.Core.ApplicationService.ApplicationServices.UserLogin
{
    public interface IUserLoginService
    {
        Task<string> Login(LoginDto login);

        Task<Entities.User> LoginUser(LoginDto login);

        Task<int> ValidateUser(string Token);
    }
}