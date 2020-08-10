using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Application.Interface
{
    public interface IUserService
    {
        Task RegisterUserInfo(RegisterUserDto model);

        Task<(string UserName, string Id)> GetLoginInfo(LoginUserDto login);

        Task<UserInfoDto> GetCurrentUse(string Id);
    }
}
