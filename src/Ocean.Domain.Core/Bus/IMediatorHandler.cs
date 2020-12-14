using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ocean.Domain.Core.Events;

namespace Ocean.Domain.Core.Bus
{
   public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;

        Task<object> SendCommand<T>(T command) where T : IBaseRequest;
    }
}
