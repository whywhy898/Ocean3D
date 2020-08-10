using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Ocean.Infrastructure.JwtBreare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class JwtConfigExtensions
    {
        public static IServiceCollection AddCustromJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {

            var jwtconfig = configuration?.GetSection("JWT");
            services.AddJwtService(jwtconfig);
            var jwtSettings = new JWTConfig();
            configuration.Bind("JWT", jwtSettings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                //x.RequireHttpsMetadata = false;
                //x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey)),
                    ValidIssuer = jwtSettings.Issuer,//token.Issuer,
                    ValidAudience = jwtSettings.Audience,//token.Audience,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                };
                x.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }

    }
}
 
