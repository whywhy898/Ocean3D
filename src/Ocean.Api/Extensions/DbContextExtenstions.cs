using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Ocean.Domain.Core.SeedWork;
using Ocean.Infrastructure.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class DbContextExtenstions
    {
        public static readonly ILoggerFactory MyLoggerFactory
         = LoggerFactory.Create(builder => {
                          builder.AddFilter((category, level) =>
                                category == DbLoggerCategory.Database.Command.Name
                                && level == LogLevel.Information)
                                .AddConsole(); 
                          });

        public static IServiceCollection AddCustromDbContext(this IServiceCollection services, IConfiguration configuration)
        {
        
            services.AddDbContext<EFDbContext>(option => {
                option.UseSqlServer(configuration.GetConnectionString("MsSqlServer"))
                      .UseLoggerFactory(MyLoggerFactory);
            }
            ,ServiceLifetime.Scoped);

            services.AddDbContext<StoreDbContext>(option =>
             option.UseSqlServer(configuration.GetConnectionString("MsSqlServer"))
            ,ServiceLifetime.Scoped);

            return services;
        }
    }
}
