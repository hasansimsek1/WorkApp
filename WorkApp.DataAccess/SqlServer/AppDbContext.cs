using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WorkApp.Common.Entities;


namespace WorkApp.DataAccess.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public AppDbContext() : base("WorkAppDb")
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<DesktopMenu> DesktopMenu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<ToDo> ToDo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public DbSet<ErrorLog> ErrorLog { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
