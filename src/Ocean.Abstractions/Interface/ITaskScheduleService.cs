using Ocean.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Application.Interface
{
    public interface ITaskScheduleService
    {
        Task CreateOrUpdateTaskSchedule(string taskGroup,string taskName,string taskCron,string taskDesc);
    }
}
