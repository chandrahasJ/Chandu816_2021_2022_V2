
using System.Net;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Helpers.AutoMapperHelpers;
using BRHomeWebApi.MiddleWares;
using BRHomeWebApi.Pattern;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BRHomeWebApi.Extensions
{
    public static class ExceptionMiddleWareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app,
                                                          IWebHostEnvironment env)
        {
           app.UseMiddleware<ExceptionMiddleWare>();
        }

        public static void ConfigureInBuiltExceptionHandler(this IApplicationBuilder app,
                                                          IWebHostEnvironment env)
        {            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BRHomeWebApi v1"));
            }
            else
            {
                app.UseExceptionHandler(
                    options => {
                        options.Run(
                            async context => {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if (ex != null){
                                    await context.Response.WriteAsync(ex.Error.Message);
                                }
                            }
                        );
                    }
                );
            }
          }
    }
}