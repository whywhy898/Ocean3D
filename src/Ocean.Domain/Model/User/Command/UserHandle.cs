using MediatR;
using Ocean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean.Domain.Model.User.Command
{
    public class UserHandle : IRequestHandler<RegisterCommand, bool>
    {
        private IUserRepository userRepository;
        public UserHandle(IUserRepository _userRepository) {
            userRepository = _userRepository;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var identity = Guid.NewGuid().ToString();

            var registerInfo=new User.Entity.User(identity,request.AccountName,request.PassWord,request.TelNum);

            await  userRepository.AsyncAdd(registerInfo);

            return await userRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
