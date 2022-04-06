using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using IdentityExampleV1.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdentityExampleV1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationContext>(config => {
                config.UseInMemoryDatabase("InMemDB");
            });

            // AddIdentity registers the services 
            services
                .AddIdentity<IdentityUser, IdentityRole>(config =>
                    {
                        config.Password.RequiredLength = 4;
                        config.Password.RequireNonAlphanumeric = false;
                        config.Password.RequireUppercase = false;
                        config.Password.RequireLowercase = false;
                        config.Password.RequireDigit = false;
                    })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(config => {
                config.Cookie.Name = "Identity.Cookies";
                config.LoginPath = "/Account/Login";
                config.AccessDeniedPath = "/Home/UnAuthorize";
            });

            //services.AddAuthentication("CookieSchema")
            //        .AddCookie("CookieSchema", config => {
            //            config.Cookie.Name = "Driver.Cookies";
            //            config.LoginPath = "/Home/Authentication";
            //            config.AccessDeniedPath = "/Home/UnAuthorize";
            //        });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Who are you 
            app.UseAuthentication();

            // Are you allowed to acces the page 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
