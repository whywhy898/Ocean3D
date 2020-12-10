using MediatR;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.TaskSchedule.Command
{
   public class TaskCommand:IRequest<bool>
    {
        public string TaskGroup { get; set; }
        public string TaskName { get; set; }
        public string TaskCron { get; set; }
        public string TaskDescp { get; set; }
        public TaskCommand(string taskGroup,string taskName,string taskCron,string taskDescp)
        {
            TaskGroup = taskGroup;
            TaskName = taskName;
            TaskCron = taskCron;
            TaskDescp = taskDescp;
        }
    }
}
