using FluentValidation;
using Ocean.Domain.Model.User.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Validations
{
  public  class RegisterUserVaildate : AbstractValidator<RegisterCommand>
    {
        public RegisterUserVaildate()
        {
            RuleFor(a => a.AccountName).NotEmpty();
            RuleFor(a => a.PassWord).Length(6, 15).WithMessage("密码必须在6到15位之间")
                .When(a=>a.PassWord!=a.AgainPassWord).WithMessage("两次密码输入不一致");
        }
    }
}
