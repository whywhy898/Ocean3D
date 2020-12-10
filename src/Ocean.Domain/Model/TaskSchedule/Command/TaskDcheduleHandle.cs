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
   public class TaskDcheduleHandle:IRequestHandler<TaskCommand,bool>
    {
        private readonly ITaskJobRepository _taskJobRepository;
        private readonly IServiceProvider _serviceProvider;

        public TaskDcheduleHandle(ITaskJobRepository taskJobRepository,
            IServiceProvider serviceProvider)
        {
            _taskJobRepository = taskJobRepository;
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> Handle(TaskCommand request, CancellationToken cancellationToken)
        {
            var providehash = _serviceProvider.GetHashCode();
            Console.WriteLine($"providehash:{providehash},dbcontext:{_taskJobRepository.UnitOfWork.GetHashCode()}");
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
