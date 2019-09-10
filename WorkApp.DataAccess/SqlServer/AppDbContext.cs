using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WorkApp.DataAccess.Entities;

namespace WorkApp.DataAccess.SqlServer
{
    /// <summary>
    /// Database context of the app.
    /// <para/>
    /// Inherits from : <see cref="IdentityDbContext"/>
    /// </summary>
    public class AppDbContext : IdentityDbContext
    {
        /*
         * NOTE :
         *      I personaly prefer to keep database as free as possible.
         *      I mean generally I do not force database to apply restrictions like nvarchar length etc.
         *      Because I think database issues are more difficult to deal with and database restrictions reduce the flexibility of the code.
         *      Also dealing with changes on the entities is more error-prone if database restrictions applied.
         */


            
        /// <summary>
        /// Info : There must be single constructor to be able to apply pooling logic to database context.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<DesktopMenu> DesktopMenu { get; set; }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<KanbanBoard> KanbanBoard { get; set; }
        public DbSet<KanbanBoardCard> KanbanBoardCard { get; set; }
        public DbSet<KanbanBoardColumn> KanbanBoardColumn { get; set; }
        

        /// <summary>
        /// Sets the database table relations of the entities and seeds the database.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<KanbanBoard>().HasOne(x => x.User).WithMany(x => x.KanbanBoards).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Note>().HasOne(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ToDo>().HasOne(x => x.User).WithMany(x => x.ToDoes).HasForeignKey(x => x.UserId);

            modelBuilder.Entity<NoteTag>().HasKey(x => new { x.TagId, x.NoteId });

            modelBuilder.Entity<KanbanBoardCardTag>().HasKey(x => new { x.TagId, x.CardId });

            modelBuilder.Entity<DesktopMenu>().HasData(
                    new DesktopMenu { AddedDate = DateTime.Now, IsDeleted = false, IsVisible = true, ModifiedDate = DateTime.Now, Name = "Dashboard", Id = 1 },
                    new DesktopMenu { AddedDate = DateTime.Now, IsDeleted = false, IsVisible = true, ModifiedDate = DateTime.Now, Name = "Kanban", Id = 2 },
                    new DesktopMenu { AddedDate = DateTime.Now, IsDeleted = false, IsVisible = true, ModifiedDate = DateTime.Now, Name = "Notes", Id = 3 },
                    new DesktopMenu { AddedDate = DateTime.Now, IsDeleted = false, IsVisible = true, ModifiedDate = DateTime.Now, Name = "ToDoes", Id = 4 },
                    new DesktopMenu { AddedDate = DateTime.Now, IsDeleted = false, IsVisible = true, ModifiedDate = DateTime.Now, Name = "Settings", Id = 5 }
                );
        }
    }
}
