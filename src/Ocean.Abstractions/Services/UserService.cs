using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ocean.Application.Dapper;
using Ocean.Application.Interface;
using Ocean.Application.ViewModel;
using Ocean.Domain.Core.Bus;
using Ocean.Domain.Model.User.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Application.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration;
        private IMediatorHandler _mediatR;
        public UserService(IMediatorHandler mediatR, IConfiguration configuration)
        {
            _configuration = configuration;
            _mediatR = mediatR;
        }

        public async Task<UserInfoDto> GetCurrentUse(string Id)
        {
            using (var connect = new SqlConnection(_configuration.GetConnectionString("MsSqlServer")))
            {
                var sql = $"select * from SystemUser where Id=@id";

                return await connect.QueryFirstAsync<UserInfoDto>(sql, new { id = Id });
            }
        }

        public async Task<(string UserName, string Id)> GetLoginInfo(LoginUserDto login)
        {
             using(var connect= new SqlConnection(_configuration.GetConnectionString("MsSqlServer")))
             {
                var sql = $"select * from SystemUser where AccountName=@account and PassWord=@password";

                var result = await connect.QueryFirstAsync(sql, new { account = login.Account, password = login.Password });

                if (result == null) throw new Exception("账户无效！");

                return (result.Id, result.Nick);
            }
        }

        public async Task RegisterUserInfo(RegisterUserDto model)
        {
            var registerCommand = new RegisterCommand(model.AccountName,model.PassWord,model.AgainPassWord,model.TelNum);

           await _mediatR.SendCommand(registerCommand);
        }
    }
}
