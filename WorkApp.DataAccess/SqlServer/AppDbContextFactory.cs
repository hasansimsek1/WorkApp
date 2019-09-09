using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace WorkApp.DataAccess.SqlServer
{
    /// <summary>
    /// Architecture of this project needs to implement IDesignTimeDbContextFactory. For more information :
    /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("default"));

                return new AppDbContext(optionsBuilder.Options);
            }
            catch
            {
                // log
                throw;
            }
        }
    }
}
