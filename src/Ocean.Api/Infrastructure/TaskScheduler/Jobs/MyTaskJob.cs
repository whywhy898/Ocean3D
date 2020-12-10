using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocean.Application.Interface;
using Ocean.Infrastructure.Tools.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Infrastructure.TaskScheduler.Jobs
{
    public class MyTaskJob:JobWorker
    {
        private readonly ILogger<MyTaskJob> _logger;
        private readonly IServiceProvider _serviceProvider;

        public MyTaskJob(ILogger<MyTaskJob> logger,
            IOptions<List<JobWorkConfig>> taskconfigs,
            ITaskScheduleService taskScheduleService,
            IServiceProvider serviceProvider)
            :base(logger, taskconfigs, taskScheduleService)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public override async Task DoWork()
        {
            var globalhash= GlobalServiceProvider.serviceProvider.GetHashCode();
            var servicehas = _serviceProvider.GetHashCode();
            await Console.Out.WriteAsync($"当前容器hash值：{servicehas},父hash：{globalhash}");
        }
    }
}
