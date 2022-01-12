using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// The host is typically configured, built, and run by code in the Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// CreateHostBuilder method to create and configure a builder object.
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// For an HTTP workload.
        /// </summary>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // A reference to the builder after the operation completed.
                    webBuilder.UseStartup<Startup>();
                });
    }
}