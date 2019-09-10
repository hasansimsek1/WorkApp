using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WorkApp.UI.AspNetCoreMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Default webhost builder that comes with project creation.
        /// </summary>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
