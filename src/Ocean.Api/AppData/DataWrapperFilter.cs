using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ocean.Api.AppData
{
    public class DataWrapperFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context?.Result is ObjectResult objectResult)
            {
                var code = objectResult.StatusCode ?? context.HttpContext.Response.StatusCode;
                var result = new ReponseResult() { statusCode= code };
                if (code == 400)
                {
                    result.isError = true;
                    result.message =JsonConvert.SerializeObject(objectResult.Value);
                }
                else
                {
                    result.result = objectResult.Value;
                }

                objectResult.Value = result;
                objectResult.DeclaredType = objectResult.Value.GetType();
            }
            if (next == null)
                throw new ArgumentNullException(nameof(next));
            await next();
        }
    }
}
