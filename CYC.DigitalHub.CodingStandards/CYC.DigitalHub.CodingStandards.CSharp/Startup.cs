using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace CYC.DigitalHub.CodingStandards.CSharp
{
    public class Startup
    {

        public IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            if (env.IsDevelopment()) builder.AddUserSecrets<Startup>();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC to manage routing etc.
            // Always set up JSON options to return camel case and ignore referential loops.
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // If you are only using an import once then it is okay to not have it in a using statement
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // Output logging to the console to aid debugging.
            loggerFactory.AddConsole();

            // Make sure to show as much info as possible.
            loggerFactory.AddDebug();

            // If we're in a development environment it makes sense to use the developer exception page to display error info in the browser.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // The next two lines make the server deliver default files (index.html etcetc) and static files (.png, .jpg etc etc).
            app.UseDefaultFiles();
            app.UseStaticFiles();


            // Use MVC and configure our routing.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=App}/{action=Index}/{id?}");
            });

            // Run the app - it's the Kestrel web server so in live we should be sure to hook it into IIS for management, bindings, ssl etc.
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
