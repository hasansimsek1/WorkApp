using Autofac;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkApp.DataAccess.SqlServer;
using WorkApp.Respository.Interfaces;
using WorkApp.Respository.Repositories;
using WorkApp.Service.Interfaces;
using WorkApp.Service.Services;
using WorkApp.UI.Wpf.Interfaces;
using WorkApp.UI.Wpf.ViewModel;

/// <summary>
/// 
/// </summary>
namespace WorkApp.UI.Wpf.Startup
{
    /// <summary>
    /// 
    /// </summary>
    public class Bootstrapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();

            builder.RegisterType<AppDbContext>().As<DbContext>();

            builder.RegisterGeneric(typeof(CrudService<>)).As(typeof(ICrudService<>));
            builder.RegisterGeneric(typeof(SqlRespository<>)).As(typeof(ICrudRepository<>));

            builder.RegisterType<DrawerViewModel>().As<IDrawerViewModel>();
            
            builder.RegisterType<HeaderViewModel>().As<IHeaderViewModel>();
            builder.RegisterType<ToDoViewModel>().As<IToDoViewModel>();

            return builder.Build();
        }
    }
}
