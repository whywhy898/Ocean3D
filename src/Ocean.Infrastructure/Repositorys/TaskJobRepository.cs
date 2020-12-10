using Ocean.Domain.Model.TaskSchedule.Entity;
using Ocean.Domain.Repository;
using Ocean.Infrastructure.Context;

namespace Ocean.Infrastructure.Repositorys
{
    public class TaskJobRepository : Repository<TaskJob, string>, ITaskJobRepository
    {
        public TaskJobRepository(EFDbContext context) : base(context)
        {

        }
    }
}
