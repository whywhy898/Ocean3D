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
        private readonly ILogger _logger;
        private readonly IOptions<List<JobWorkConfig>> _taskconfigs;
        private readonly ITaskScheduleService _taskScheduleService;

        public JobWorker(ILogger logger,
            IOptions<List<JobWorkConfig>> taskconfigs,
            ITaskScheduleService taskScheduleService)
        {
            _logger = logger;
            _taskconfigs = taskconfigs;
            _taskScheduleService = taskScheduleService;
        }

        public abstract Task DoWork();

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                await DoWork();
                Task.WaitAll();
                await RegWorkToDb();
            }
            catch (Exception ex)
            {
                _logger.LogError("\r\n"+ex.Message.ToString()+"\r\n"+ex.StackTrace);
            }
        }

        public async Task RegWorkToDb()
        {
            var jobType = this.GetType();
            var jobName = jobType.Name;

            var config = _taskconfigs.Value.Where(a => a.TaskName == jobName).FirstOrDefault();
            await _taskScheduleService.CreateOrUpdateTaskSchedule(config?.GroupName, config?.TaskName,config?.TriggerTime,config?.TaskDescription);
        }
    }
}
