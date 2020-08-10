using MediatR;
using Ocean.Domain.Hostility.Entity;
using Ocean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean.Domain.Hostility.Command
{
    public class HostilityHandle : IRequestHandler<SetSurpassCommand, bool>,
         IRequestHandler<AddHostilityCommand,bool>
     {
        private IHostilityRepository _hostilityRepository;
        public HostilityHandle(IHostilityRepository hostilityRepository)
        {
            _hostilityRepository = hostilityRepository;

        }

        public async Task<bool> Handle(SetSurpassCommand request, CancellationToken cancellationToken)
        {
            var info = await _hostilityRepository.AsyncGetSingle(request._hostilityId);

            if (info == null) return false;

            info.SetSurpass();

            return await _hostilityRepository.UnitOfWork.SaveEntitiesAsync();
        }

        public async Task<bool> Handle(AddHostilityCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid().ToString();
            var hostility = new HostilityEntity(id, request.QQNumber,request.HostilityName,
                request.RoleLevel,request.MilitaryPower, request.HostilityLevel,request.Remark,"why");

            _hostilityRepository.Add(hostility);

            return await _hostilityRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
