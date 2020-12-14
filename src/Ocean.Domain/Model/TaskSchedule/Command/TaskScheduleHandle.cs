using MediatR;
using Microsoft.EntityFrameworkCore;
using Ocean.Domain.Model.TaskSchedule.Entity;
using Ocean.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ocean.Domain.Model.TaskSchedule.Command
{
   public class TaskScheduleHandle:IRequestHandler<TaskCommand,bool>
    {
        private readonly ITaskJobRepository _taskJobRepository;

        public TaskScheduleHandle(ITaskJobRepository taskJobRepository)
        {
            _taskJobRepository = taskJobRepository;
        }

        public async Task<bool> Handle(TaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _taskJobRepository.GetAll(a => a.TaskName == request.TaskName).FirstOrDefaultAsync();
            if (task == null)
            {
                var createTask = new TaskJob(Guid.NewGuid().ToString(),request.TaskGroup,request.TaskName,request.TaskCron,request.TaskDescp);
                await _taskJobRepository.AsyncAdd(createTask);
            }
            else {
                task.UpdateSchedule(request.TaskGroup, request.TaskName, request.TaskCron, request.TaskDescp);
                _taskJobRepository.Update(task);
            }

            return await _taskJobRepository.UnitOfWork.SaveEntitiesAsync(); 
        }
    }
}
