using IdentityModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddCustromAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("refresh", policy => policy.RequireClaim(JwtClaimTypes.JwtId, "refresh"));
            });
            return services;
        }
    }
}
