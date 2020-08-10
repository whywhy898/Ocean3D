
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.JwtBreare
{
   public static class JwtExtensions
    {

        public static void AddJwtService(this IServiceCollection services, IConfigurationSection section)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.Configure<JWTConfig>(section);
        }
    }
}
