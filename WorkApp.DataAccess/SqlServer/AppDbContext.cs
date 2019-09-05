using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WorkApp.Common.Entities;

namespace WorkApp.DataAccess.SqlServer
{
    /// <summary>
    /// 
    /// </summary>
    public class AppDbContext : IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        //public DbSet<DesktopMenu> DesktopMenu { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<ToDo> ToDo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Note> Note { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Tag> Tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<KanbanBoard> KanbanBoard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<KanbanBoardCard> KanbanBoardCard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<KanbanBoardColumn> KanbanBoardColumn { get; set; }



        /// <summary>
        /// 
        /// </summary>
        //public DbSet<ErrorLog> ErrorLog { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<ApplicationUser>().HasMany(x => x.KanbanBoards).WithOne();

            modelBuilder.Entity<KanbanBoard>().HasOne(x => x.User).WithMany(x => x.KanbanBoards).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Note>().HasOne(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ToDo>().HasOne(x => x.User).WithMany(x => x.ToDoes).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<NoteTag>().HasKey(x => new { x.TagId, x.NoteId });

            modelBuilder.Entity<KanbanBoardCardTag>().HasKey(x => new { x.TagId, x.CardId });
        }
    }
}
