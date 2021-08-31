using System;
using System.Net;
using System.Threading.Tasks;
using BRHomeWebApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BRHomeWebApi.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleWare> logger;
        private readonly IHostEnvironment env;

        public ExceptionMiddleWare(RequestDelegate next,
                                ILogger<ExceptionMiddleWare> logger,
                                IHostEnvironment env)
        {
            this.env = env;
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {                
                logger.LogError(ex.Message);
                logger.LogError(ex.StackTrace);

                ApiError response = CreateApiError(ex);
                context.Response.StatusCode = response.ErrorCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }

        public ApiError CreateApiError(Exception ex)
        {
            ApiError response;
            string message = "";
            HttpStatusCode statusCode = GetStatusCode(ex, out message);
            
            if(env.IsDevelopment())
            {
                response = new ApiError((int)statusCode, ex.Message, ex.StackTrace.ToString());
            }
            else
            {
                response = new ApiError((int)statusCode, message);
            }

            return response;
        }

        public HttpStatusCode GetStatusCode(Exception ex, out string message)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            message = "";
            var excpectionType = ex.GetType();
            if(excpectionType == typeof(UnauthorizedAccessException))
            {
                statusCode = HttpStatusCode.Forbidden;
                message = "You are not authorized";
            }
            else if(excpectionType == typeof(InvalidTimeZoneException))
            {
                statusCode = HttpStatusCode.PreconditionFailed;
                message = "You are not allowed";
            }
            else
            {
                message = "Some error has occured.";
            }
            return statusCode;
        }
    }
}