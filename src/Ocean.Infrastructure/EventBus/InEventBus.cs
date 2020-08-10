using MediatR;
using Microsoft.Extensions.Configuration;
using Ocean.Domain.Core.Bus;
using Ocean.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Infrastructure.EventBus
{
    public class InEventBus : IMediatorHandler
    {
        //构造函数注入
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;
        private readonly IConfiguration _configuration;

        public InEventBus(IEventStore eventStore, IMediator mediator, IConfiguration configuration)
        {
            _eventStore = eventStore;
            _mediator = mediator;
            _configuration = configuration;
        }

        public async Task PublishEvent<T>(T @event) where T : Event
        {
            var eventSwitch = _configuration.GetValue<bool>("Switch:IsOpenEventSourcing");

            if (eventSwitch) {
                _eventStore?.Save(@event);
            }
               

            await _mediator.Publish(@event);
        }

        public async Task SendCommand<T>(T command) where T : IBaseRequest
        {
            await _mediator.Send(command);
        }
    }
}
