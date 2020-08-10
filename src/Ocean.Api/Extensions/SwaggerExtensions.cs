using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustromSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ocean3D API",
                    Description = "API for Ocean",
                    Contact = new OpenApiContact() { Name = "why", Email = "whywhy898@outlook.com" }
                });

                //把生产的XML文件加载进来
                option.IncludeXmlComments("OceanSwagger.xml", true);

                //添加一个必须的全局安全信息，和AddSecurityDefinition方法指定的方案名称一致即可，CoreAPI。
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"}
                        },Array.Empty<string>()
                    }
                });

                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 在下方输入Bearer {token} 即可，注意两者之间有空格",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
            });

            return services;
        }
    }
}
