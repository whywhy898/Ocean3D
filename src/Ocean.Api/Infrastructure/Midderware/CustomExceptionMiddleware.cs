using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Ocean.Api.AppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ocean.Api.Infrastructure.Midderware
{
    /// <summary>
    /// 全局异常处理中间件
    /// </summary>
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                var statusCode = 500;
                if (e is ArgumentException)
                {
                    statusCode = 200;
                }
                _logger.LogError("\r\n" + context.Request.Path.Value + "\r\n" + e.Message.ToString() + "\r\n" + e.StackTrace);
                await HandleExceptionAsync(context, statusCode, e.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var msg = "";

                if (statusCode == 401)
                {
                    msg = "未授权";
                }
                else if (statusCode == 402)
                {
                    msg = "token过期";
                }
                else if (statusCode == 404)
                {
                    msg = "未找到服务";
                }
                else if (statusCode == 502)
                {
                    msg = "请求错误";
                }

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    _logger.LogError(context.Request.Path.Value + "\r\n" + msg);

                    await HandleExceptionAsync(context, statusCode, msg);
                }
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, int statusCode, string msg)
        {
            var data = new ReponseResult { statusCode = statusCode, isError = false, message = msg };
            var result = JsonSerializer.Serialize(data);
            context.Response.ContentType = "application/json;charset=utf-8";

            await context.Response.WriteAsync(result);
        }
    }
    
}
