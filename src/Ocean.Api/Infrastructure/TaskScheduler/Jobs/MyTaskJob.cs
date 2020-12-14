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
        private readonly IServiceProvider _serviceProvider;

        public MyTaskJob(IServiceProvider serviceProvider)
            :base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task DoWork()
        {
            var servicehas = _serviceProvider.GetHashCode();
            await Console.Out.WriteAsync($"当前容器hash值：{servicehas}");
        }
    }
}
