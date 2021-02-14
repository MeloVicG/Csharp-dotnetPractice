using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PracticeDotNetCore
{
    public class Startup
    {
        // public Startup(IWebHostEnvironment env)
        // {
        //     // run this in the debugger, and inspect the "env" object! You can use this object to tell you 
        //     // the root path of your application, for the purposes of reading from local files, and for            
        //     // checking environment variables - such as if you are running in Development or Production 
        //     Console.WriteLine(env.ContentRootPath);
        //     Console.WriteLine(env.IsDevelopment());
        // }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //this line was added
            services.AddMvc(options => options.EnableEndpointRouting = false); //options => options.EnableEndpointRouting = false
                                // inside () this is correlated with line 45 app.useEndpoints
                                //if this is enabled do not need line 45
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //show whatever error is generated
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // We will now add the UseStaticFiles() middleware, which allows our app to access our static files.
            app.UseStaticFiles();
            // app.UseRouting();
            //replace app.UseRouting() for MVC
            app.UseMvc();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello buddy");
            //     });
            // });
        }
    }
}
