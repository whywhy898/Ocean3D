using Ocean.Application.Interface;
using Ocean.Domain.Core.Bus;
using Ocean.Domain.Model.TaskSchedule.Command;
using System.Threading.Tasks;

namespace Ocean.Application.Services
{
    public class TaskScheduleService : ITaskScheduleService
    {
        private readonly IMediatorHandler _mediatR;
        public TaskScheduleService(IMediatorHandler mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task CreateOrUpdateTaskSchedule(string taskGroup, string taskName, string taskCron, string taskDesc)
        {
            var command = new TaskCommand(taskGroup,taskName,taskCron,taskDesc);
            await _mediatR.SendCommand(command);
        }
    }
}
