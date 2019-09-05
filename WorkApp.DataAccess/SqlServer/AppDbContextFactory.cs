using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace WorkApp.DataAccess.SqlServer
{
    /// <summary>
    /// Architecture of this project needs to implement IDesignTimeDbContextFactory. For more information :
    /// https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dbcontext-creation
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        //private readonly IConfiguration _config;

        //public AppDbContextFactory(IConfiguration config)
        //{
        //    _config = config;
        //}

        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("default"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
