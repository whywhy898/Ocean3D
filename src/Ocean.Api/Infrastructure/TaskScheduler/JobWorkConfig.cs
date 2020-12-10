using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Infrastructure.TaskScheduler
{
    public class JobWorkConfig
    {
        public string GroupName { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string TriggerTime { get; set; }

        public bool IsOpen { get; set; }
    }
}
