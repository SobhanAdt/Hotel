using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.UserLoginDto;

namespace App.Core.ApplicationService.ApplicationServices.UserLogin
{
    public interface IUserLoginService
    {
        Task<string> CreateToken(LoginDto login);


        Task<int> ValidateUser(string Token);
    }
}