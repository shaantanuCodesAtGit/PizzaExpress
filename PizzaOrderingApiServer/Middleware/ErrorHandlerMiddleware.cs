using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Utility.Helper;

namespace PizzaOrderingApiServer.Middleware
{
    /// <summary>
    /// middleware which will catch any unhandled or user thrown execptions.
    /// </summary>
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (HttpStatusCodeException exception)
            {
                // do logging here.

                var errorJson = JsonConvert.SerializeObject(new
                {
                    Code = exception.StatusCode,
                    exception.Message,
                });

                httpContext.Response.StatusCode = exception.StatusCode;

                await httpContext.Response.WriteAsync(errorJson);
            }
            catch (Exception e)
            {
                var errorJson = JsonConvert.SerializeObject(new
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = "Some thing went wrong please try again.",
                });

                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                await httpContext.Response.WriteAsync(errorJson);
            }
        }
    }

    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpErrorHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
