using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Robotics.Models;
using Robotics.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Robotics
{
    public class Startup
    {
        public object CallContext;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

       
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //    services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Other code...

            services.AddScoped<GetCookieCollection>();


            // Add Localization.

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();
            services.AddScoped<LanguageActionFilter>();
            services.AddScoped<HttpContextService>();

            services.Configure<RequestLocalizationOptions>(opts =>
            {
                var supportedCultures = new List<CultureInfo>
                {
            new CultureInfo("en-US"),
            new CultureInfo("de-CH")
        };
                opts.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(culture:  "en-US", uiCulture: "en-US");
                opts.SupportedCultures = supportedCultures;
                opts.SupportedUICultures = supportedCultures;
            });

            services.AddDbContext<RoboticsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Database")));
            
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRequestLocalization();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseStaticFiles();




            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "default",
                  template: "{culture}/{controller}/{action}/{id?}",
                 defaults: new {  culture = "en-US", controller = "Home", action = "Index" },
                constraints: new { culture = new RegexRouteConstraint("^[a-z]{2}(?:-[A-Z]{2})?$") }
                );  // en or en-US 

             //   routes.MapRoute(
             //       name: "default",
             //     template: "{controller=Home}/{action=Index}/{id?}"
             //   );
            }
            );
        }
    }
}
