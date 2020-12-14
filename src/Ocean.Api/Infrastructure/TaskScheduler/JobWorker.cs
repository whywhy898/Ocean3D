using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocean.Application.Interface;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Infrastructure.TaskScheduler
{
    public abstract class JobWorker:IJob
    {
        private readonly IServiceProvider _serviceProvider;
        public JobWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public abstract Task DoWork();

        public async Task Execute(IJobExecutionContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _logger= _serviceProvider?.GetService(typeof(Logger<JobWorker>)) as ILogger;
                try
                {
                    var provider = scope.ServiceProvider;
                    await DoWork();
                    Task.WaitAll();
                    await RegWorkToDb(provider);
                }
                catch (Exception ex)
                {
                    _logger.LogError("\r\n" + ex.Message.ToString() + "\r\n" + ex.StackTrace);
                }
            }
        }

        public async Task RegWorkToDb(IServiceProvider serviceProvider)
        {
            var taskScheduleService = serviceProvider?.GetService(typeof(ITaskScheduleService)) as ITaskScheduleService;
            var taskconfigs = serviceProvider?.GetService(typeof(IOptions<List<JobWorkConfig>>)) as IOptions<List<JobWorkConfig>>;

            var jobType = this.GetType();
            var jobName = jobType.Name;

            var config = taskconfigs.Value.Where(a => a.TaskName == jobName).FirstOrDefault();
            await taskScheduleService.CreateOrUpdateTaskSchedule(config?.GroupName, config?.TaskName,config?.TriggerTime,config?.TaskDescription);
        }
    }
}
