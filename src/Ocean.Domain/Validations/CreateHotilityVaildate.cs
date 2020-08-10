using FluentValidation;
using Ocean.Domain.Hostility.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Validations
{
    public class CreateHotilityVaildate : AbstractValidator<AddHostilityCommand>
    {
        public CreateHotilityVaildate()
        {
            RuleFor(command => command.QQNumber).NotEmpty().Length(5, 11).WithMessage("QQ号码不允许5位到11位数之间！");
            RuleFor(command => command.HostilityName).NotEmpty();
            RuleFor(command => command.RoleLevel).Must(Rolelevel);
        }

        private bool Rolelevel(int RoleLevel)
        {
            return RoleLevel<109;
        }
    }
}
