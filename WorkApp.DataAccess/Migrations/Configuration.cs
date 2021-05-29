namespace WorkApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using WorkApp.Common.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<WorkApp.DataAccess.SqlServer.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WorkApp.DataAccess.SqlServer.AppDbContext context)
        {
            context.DesktopMenu.AddOrUpdate(
                x => x.Name,
                new DesktopMenu { Id = 1, Name = "Kanban", AddedDate = DateTime.Now, IsDeleted = false      , IsVisible = true},
                new DesktopMenu { Id = 2, Name = "To Do", AddedDate = DateTime.Now, IsDeleted = false       , IsVisible = true},
                new DesktopMenu { Id = 3, Name = "Note", AddedDate = DateTime.Now, IsDeleted = false        , IsVisible = true},
                new DesktopMenu { Id = 4, Name = "Mail", AddedDate = DateTime.Now, IsDeleted = false        , IsVisible = true},
                new DesktopMenu { Id = 5, Name = "Message", AddedDate = DateTime.Now, IsDeleted = false     , IsVisible = true},
                new DesktopMenu { Id = 6, Name = "Settings", AddedDate = DateTime.Now, IsDeleted = false    , IsVisible = true}
                );

            context.ToDo.AddOrUpdate(
                x => x.Id,
                new ToDo { Id = 1, Text = "To do 1", IsCompleted = false, IsDeleted = false, AddedDate = DateTime.Now },
                new ToDo { Id = 2, Text = "To do 2", IsCompleted = false, IsDeleted = false, AddedDate = DateTime.Now },
                new ToDo { Id = 3, Text = "To do 3", IsCompleted = false, IsDeleted = false, AddedDate = DateTime.Now },
                new ToDo { Id = 4, Text = "To do 4", IsCompleted = false, IsDeleted = false, AddedDate = DateTime.Now }
                );
        }
    }
}
