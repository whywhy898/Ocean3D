using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocean.Api.Extensions;
using Serilog;

namespace Ocean.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSerilog((hostingContext, builder) =>
                    {
                        var serilog = new Ocean.Api.Extensions.SerilogAisst();
                        hostingContext.Configuration.GetSection("Serilog").Bind(serilog);
                        builder.CreateLogConfig(serilog);      
                    });
                });
    }
}
