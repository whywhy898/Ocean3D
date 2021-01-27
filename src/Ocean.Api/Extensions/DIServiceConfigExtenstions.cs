using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocean.Api.AppData;
using Ocean.Api.Infrastructure.Services;
using Ocean.Api.Infrastructure.TaskScheduler;
using Ocean.Application.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ocean.Api.Extensions
{
    public static class DIServiceConfigExtenstions
    {
        public static IServiceCollection AddDIServiceConfig(this IServiceCollection services,IConfiguration configuration)
        {
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Ocean", StringComparison.OrdinalIgnoreCase)).ToList();

            services.Scan(scan => scan
                  .FromAssemblies(assemblys)
                  .AddClasses(c => c.Where(t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase)))
                  .AsImplementedInterfaces()
                  .WithTransientLifetime()
                  .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase)))
                  .AsImplementedInterfaces()
                  .WithTransientLifetime()
            );

            //注入MVC过虑器
            services.AddSingleton<IConfigureOptions<MvcOptions>, MvcOptionConfig>();

            //注入当前用户信息
            services.AddScoped<IIdentityService, IdentityService>();

            //注入当前请求上下文
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            //注入定时任务所需的配置
            services.Configure<List<JobWorkConfig>>(configuration?.GetSection("TaskSchedule"));

            //跨域配置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });

            return services;
        }
    }
}
