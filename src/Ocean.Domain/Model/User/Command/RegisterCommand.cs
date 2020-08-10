using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.User.Command
{
    public class RegisterCommand : IRequest<bool>
    {
        public string AccountName { get; set; }

        public string PassWord { get; set; }

        public string AgainPassWord { get; set; }

        public string TelNum { get; set; }

        public RegisterCommand(string accountName,string password,string againPassWord,string telNum) {

            AccountName = accountName;
            PassWord = password;
            AgainPassWord = againPassWord;
            TelNum = telNum;
        }
    }
}
