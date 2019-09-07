using Autofac;
using Microsoft.EntityFrameworkCore;
using WorkApp.Common.Entities;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;
using WorkApp.Service.Services;
using WorkApp.UI.Wpf.Interfaces;
using WorkApp.UI.Wpf.ViewModel;


namespace WorkApp.UI.Wpf.Startup
{
    /// <summary>
    /// Configures the Autofac at the beginning of the app. 
    /// Initiated in the App.xaml.cs.
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// Keeps the dependency injection configurations that will be used by the app.
        /// </summary>
        /// <returns><see cref="IContainer"/></returns>
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<AppDbContext>().As<DbContext>();
            
            builder.RegisterType<SqlRespository<KanbanBoard>>().As<ICrudRepository<KanbanBoard>>()
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));
            builder.RegisterType<SqlRespository<ToDo>>().As<ICrudRepository<ToDo>>()
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));
            builder.RegisterType<SqlRespository<Note>>().As<ICrudRepository<Note>>()
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));

            builder.RegisterType<SqlRespository<DesktopMenu>>().As<ICrudRepository<DesktopMenu>>()
                .WithParameter((p, c) => p.ParameterType == typeof(AppDbContext), (p, c) => new AppDbContextFactory().CreateDbContext(new string[0]));


            builder.RegisterGeneric(typeof(CrudService<>)).As(typeof(ICrudService<>));

            builder.RegisterType<DrawerViewModel>().As<IDrawerViewModel>();
            builder.RegisterType<ToDoViewModel>().As<IToDoViewModel>();

            return builder.Build();
        }
    }
}
