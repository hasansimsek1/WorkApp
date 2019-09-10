using Autofac;
using AutoMapper;
using WorkApp.Common.Configurations;
using WorkApp.Service.Extensions;
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
        /// <returns><see cref="IContainer"/>Autofac dependency container.</returns>
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<DrawerViewModel>().As<IDrawerViewModel>();
            builder.RegisterType<ToDoViewModel>().As<IToDoViewModel>();
            builder.Register(x => new AutoMapperConfiguration().Configure().CreateMapper()).As<IMapper>();
            builder.AddAppServices();

            return builder.Build();
        }
    }
}
