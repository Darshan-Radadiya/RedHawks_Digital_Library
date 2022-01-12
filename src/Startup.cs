using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Startup class - entry point of web.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The host is typically configured and run by code in the Startup class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            //The host is typically configured and run by code in startup class.
            Configuration = configuration;
        }

        public IConfiguration Configuration
        {
            //This method gets called by the runtime. Use this method to add services.
            get;
        }

        /// <summary>
        /// The method gets called and add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // This method gets called by the runtime. Use this method to add services to the container.
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
        }

        /// <summary>
        /// A class the provides the mechanisms to configure an appliaction's request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //A reference to the app after the operation has completed.
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();
            // This method overload marks the files in web root as servable.
            app.UseStaticFiles();
            // It adds route matching to the middleware pipeline. 
            // This middleware looks at the set of endpoints defined in the app, and selects the best match based on the request.
            app.UseRouting();
            // It enables authorization capabilities. 
            app.UseAuthorization();
            // It adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
            });
        }
    }
}