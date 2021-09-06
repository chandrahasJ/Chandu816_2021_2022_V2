
using System.Net;
using System.Text;
using BRHomeWebApi.DataC;
using BRHomeWebApi.Extensions;
using BRHomeWebApi.Helpers.AutoMapperHelpers;
using BRHomeWebApi.MiddleWares;
using BRHomeWebApi.Pattern;
using BRHomeWebApi.Pattern.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BRHomeWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<BRHomeDbContext>(options =>{
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //Adding AutoMapper 
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            
            //Register Services for Repos
            services.AddScoped<IUnitOfWork, UnitOfWork>();            

            var secertKey = Configuration.GetSection("AppSettings:Key").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secertKey));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opts => {
                        opts.TokenValidationParameters = new TokenValidationParameters(){                             
                             ValidateIssuerSigningKey = true,
                             ValidateAudience = false,
                             ValidateIssuer = false,
                             IssuerSigningKey = key
                        };
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BRHomeWebApi", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {    
            app.ConfigureExceptionHandler(env);
            
            //app.ConfigureInBuiltExceptionHandler(env);

            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
