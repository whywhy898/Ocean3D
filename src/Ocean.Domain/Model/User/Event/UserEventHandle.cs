using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean.Domain.Model.User.Event
{
    public class UserEventHandle : INotificationHandler<RegistedUserEvent>
    {
        private ILogger<UserEventHandle> _logger;
        public UserEventHandle(ILogger<UserEventHandle> logger)
        {
            _logger = logger;
        }
        public Task Handle(RegistedUserEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"新用户注册,账号：{notification.AccountName}.");

            return Task.CompletedTask;
        }
    }
}
