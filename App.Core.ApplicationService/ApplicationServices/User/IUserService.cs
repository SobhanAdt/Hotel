using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.USerRateDto;
using App.Core.ApplicationService.Dtos.Userto;

namespace App.Core.ApplicationService.ApplicationServices.User
{
    public interface IUserService
    {
        Task<string> InsertUser(UserInsertInputDto insertInputDto);

        Task<string> UpdateUser(UserUpdateDto updateDto);

        Task<string> DeleteUser(int id);

        Task<List<UserOutputDto>> GetAllUser();

        Task<UserOutputDto> GetSingelUser(int id);

        Task<string> InsertUserRate(UserRateInsertDto insertDto, int userId);

    }
}
