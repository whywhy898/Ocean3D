using Autofac;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocean.Api.AppData;
using Ocean.Api.Extensions;
using Ocean.Application.AutoMapper;
using Ocean.Infrastructure.Tools.Services;

namespace Ocean.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        //注入服务方法的地方DI容器
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustromDbContext(Configuration)
                .AddDIServiceConfig(Configuration)
                .AddCustromJwtConfig(Configuration)
                .AddQiartzServiceConfig(Configuration)
                .AddCustromAuthorization()
                .AddCustromSwagger()
                .AddCustromMvcConfig();

            //实体映射
            services.AddAutoMapper(typeof(AutoMapperConfig));

            // 领域命令、领域事件等注入
            services.AddMediatR(typeof(Startup));

        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            //所有命令、事件的注入
            builder.RegisterModule(new AutoFacModule());
        }

        // 启动中间件设置
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            GlobalServiceProvider.serviceProvider = app?.ApplicationServices.CreateScope().ServiceProvider;

            app.UseCustomExceptionMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                //如果设置根目录为swagger,将此值置空
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
