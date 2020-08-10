using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Hostility.Command
{
    public class SetSurpassCommand : IRequest<bool>
    {
        public string _hostilityId { get; set; }
        public SetSurpassCommand(string hostilityId) {
            _hostilityId = hostilityId;
        }
    }
}
