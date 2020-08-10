using Microsoft.AspNetCore.Builder;
using Ocean.Api.Infrastructure.Midderware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
