using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App.Core.ApplicationService.Dtos.Userto;

namespace App.Core.ApplicationService.ApplicationServices.User
{
    public interface IUserService
    {
        string InsertUser(UserInsertInputDto insertInputDto);

        string UpdateUser(UserUpdateDto updateDto);

        string DeleteUser(int id);

        Task<List<UserOutputDto>> GetAllUser();

        Task<UserOutputDto> GetSingelUser(int id);
    }
}
