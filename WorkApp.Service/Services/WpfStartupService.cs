using Autofac;
using Microsoft.EntityFrameworkCore;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    public class WpfStartupService : IWpfStartupService
    {
        public void ConfigureAppServices(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().As<DbContext>();
            builder.RegisterType<DesktopMenuService>().As<IDesktopMenuService>();
            builder.RegisterType<KanbanBoardService>().As<IKanbanBoardService>();
            builder.RegisterType<NoteService>().As<INoteService>();
            builder.RegisterType<ToDoService>().As<IToDoService>();

            builder.RegisterGeneric(typeof(SqlRespository<,>)).As(typeof(ICrudRepository<,>))
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));
        }
    }
}
