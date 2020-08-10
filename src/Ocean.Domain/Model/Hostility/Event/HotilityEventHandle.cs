using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean.Domain.Hostility.Event
{
    public class HotilityEventHandle : INotificationHandler<CraetedHotilityEvent>
    {
        private ILogger<HotilityEventHandle> _logger;
        public HotilityEventHandle(ILogger<HotilityEventHandle> logger)
        {
            _logger = logger;
        }
        public Task Handle(CraetedHotilityEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"新增仇恨信息，ID：{notification.Id}");

            return Task.CompletedTask;
        }
    }
}
