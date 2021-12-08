using Heroes_Api.Contracts;
using Heroes_Api.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Heroes_Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private RequestDelegate _next;
        private ILoggerService _logger;
        
        public ExceptionHandlerMiddleware(RequestDelegate next,ILoggerService logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (Exception exception)
            {
                _logger.LogError($"Internal error: {exception}");
                await HandleExceptionAsync(httpContext, exception);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error"
            }.ToString());
        }
    }
}
