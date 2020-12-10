using Ocean.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Domain.Model.TaskSchedule.Entity
{
   public class TaskJob:BaseEntity<string>,IAggregateRoot
    {
        public string TaskGroup { get;private set; }
        public string TaskName { get; private set; }
        public string TaskCron { get; private set; }
        public string TaskDescription { get; private set; }

        public TaskJob()
        {

        }

        public TaskJob(string taskid, string taskGroup, string taskName, string taskCron, string taskDescription)
        {
            Id = taskid;
            TaskGroup = taskGroup;
            TaskName = taskName;
            TaskCron = taskCron;
            TaskDescription = taskDescription;
            CreateTime = DateTime.Now;
            CreateBy = "Task";
        }

        public void UpdateSchedule(string taskGroup, string taskName, string taskCron, string taskDescription)
        {
            TaskGroup = taskGroup;
            TaskName = taskName;
            TaskCron = taskCron;
            TaskDescription = taskDescription;
            UpdateTime = DateTime.Now;
            UpdateBy = "Task";
        }
    }
}
