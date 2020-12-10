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

        //ע����񷽷��ĵط�DI����
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustromDbContext(Configuration)
                .AddDIServiceConfig(Configuration)
                .AddCustromJwtConfig(Configuration)
                .AddQiartzServiceConfig(Configuration)
                .AddCustromAuthorization()
                .AddCustromSwagger()
                .AddCustromMvcConfig();

            //ʵ��ӳ��
            services.AddAutoMapper(typeof(AutoMapperConfig));

            // ������������¼���ע��
            services.AddMediatR(typeof(Startup));

        }

        public static void ConfigureContainer(ContainerBuilder builder)
        {
            //��������¼���ע��
            builder.RegisterModule(new AutoFacModule());
        }

        // �����м������
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
                //������ø�Ŀ¼Ϊswagger,����ֵ�ÿ�
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
