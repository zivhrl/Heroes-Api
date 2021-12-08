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
                _logger.LogError($"Error Code: {exception}");
                await HandleExceptionAsync(httpContext, exception);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode;
            context.Response.ContentType = "application/json";
            switch (exception.Message)
            {
                case "400":
                    statusCode = 400;
                    break;
                case "401":
                    statusCode = 401;
                    break;
                case "405":
                    statusCode = 405;
                    break;
                case "409":
                    statusCode = 409;
                    break;
                default:
                    statusCode = 500;
                    break;
            }
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
            }.ToString());
        }
    }
}
