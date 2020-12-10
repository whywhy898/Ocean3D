using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocean.Api.Infrastructure.TaskScheduler;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class QuartzServiceConfigExtenstion
    {
        public static IServiceCollection AddQiartzServiceConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var taskSwitch = configuration.GetValue<bool>("Switch:IsOpenTaskSchedule");
            if (taskSwitch)
            {
                services.AddQuartz(q =>
                {
                    q.SchedulerId = "mySchedule";
                    q.UseMicrosoftDependencyInjectionJobFactory(option =>
                    {
                        option.AllowDefaultConstructor = true;
                    });
                    q.UseSimpleTypeLoader();
                    q.UseInMemoryStore();
                    q.UseDefaultThreadPool(tp =>
                    {
                        tp.MaxConcurrency = 10;
                    });

                    q.RegistTasks(services);

                });

                services.AddQuartzHostedService(option =>
                {
                    option.WaitForJobsToComplete = true;
                });

            }
            return services;
        }

        private static void RegistTasks(this IServiceCollectionQuartzConfigurator Quartz, IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var tasks = provider.GetRequiredService<IOptions<List<JobWorkConfig>>>().Value;

            tasks.ForEach(task =>
            {
                if (task.IsOpen)
                {
                    var assly = AppDomain.CurrentDomain.GetAssemblies();
                    var type = assly.SelectMany(a => a.GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(IJob)) && t.Name == task.TaskName))
                    .FirstOrDefault();

                    var jobkey = new JobKey(task.TaskName,task.TaskDescription);

                    Action<IJobConfigurator> action = (job) =>
                    {
                        job.StoreDurably()
                        .WithIdentity(jobkey)
                        .WithDescription(task.TaskDescription);
                    };

                    var method = typeof(Quartz.ServiceCollectionExtensions).GetMethods()
                    .Where(a=>a.Name=="AddJob").FirstOrDefault();
                    var generic = method.MakeGenericMethod(type);
                    generic.Invoke(null, new object[] { Quartz,action });

                    Quartz.AddTrigger(t => t
                       .WithIdentity(task.TaskName)
                       .ForJob(jobkey)
                       .StartNow()
                       .WithSimpleSchedule(x=>x.WithInterval(TimeSpan.FromSeconds(60)).WithRepeatCount(0))
                       //.WithCronSchedule(task.TriggerTime)
                       .WithDescription(task.TaskDescription)
                    );
                }
            });

        }
    }
}
