using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class MvcOptionExtensions
    {
        public static IServiceCollection AddCustromMvcConfig(this IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(option => {
                    // 忽略循环引用,规避EntityFramework导航属性json序列化时的循环引用问题 
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    // 使用默认json序列化,规避字段小驼峰命名法 
                    //setupAction.SerializerSettings.ContractResolver = new DefaultContractResolver(); 
                    // 设置json序列化的日期时间格式 
                    option.SerializerSettings.DateFormatString = "yyyy-MM-dd";
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                                    .Where(e => e.Value.Errors.Count > 0)
                                    .Select(e => new { field = e.Key, errorinfo = e.Value.Errors.First().ErrorMessage })
                                    .ToList();

                    return new BadRequestObjectResult(errors);
                };
            });

            return services;
        }
    }
}
