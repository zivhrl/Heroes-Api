using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heroes_Api.Models
{
    public class CustomValidationErrorHandler
    {
        public static void CustomValidationResponse(IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(
                options => options.InvalidModelStateResponseFactory = actionontext =>
                {
                    return new BadRequestObjectResult(new ErrorDetails
                    {
                        StatusCode = 400
                    }); 
                }
                );
        }
    }
}
