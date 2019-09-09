using Autofac;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;
using WorkApp.Service.Services;

namespace WorkApp.Service.Extensions
{
    public static class AutofacExtensions
    {
        public static void AddAppServices(this ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().As<DbContext>();
            builder.RegisterType<DesktopMenuService>().As<IDesktopMenuService>();
            builder.RegisterType<KanbanBoardService>().As<IKanbanBoardService>();
            builder.RegisterType<NoteService>().As<INoteService>();
            builder.RegisterType<ToDoService>().As<IToDoService>();

            builder.RegisterGeneric(typeof(SqlRespository<,>)).As(typeof(ICrudRepository<,>))
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));


            builder.RegisterGeneric(typeof(UserManager<>)).AsSelf();
            builder.RegisterGeneric(typeof(SignInManager<>)).AsSelf();
        }
    }
}
