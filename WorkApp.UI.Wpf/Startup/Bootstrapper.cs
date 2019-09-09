using Autofac;
using AutoMapper;
using WorkApp.Common.Configurations;
using WorkApp.Service.Extensions;
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
            builder.RegisterType<DrawerViewModel>().As<IDrawerViewModel>();
            builder.RegisterType<ToDoViewModel>().As<IToDoViewModel>();
            //builder.RegisterGeneric(typeof(CrudService<>)).As(typeof(ICrudService<>));

            /*
             * TODO :
             *      Retrieve these from service layer.
             *          Implement ConfigurationService in the service layer with these methods
             *              for AutoMapper implement a method that returns IMapper
             *              implement a method that returns AppDbContext
             *              implement a method that returns typeof(SqlRespository<>)
             *              implement a method that returns new AppDbContextFactory().CreateDbContext(new string[0])
             *          
             */
            builder.Register(x => new AutoMapperConfiguration().Configure().CreateMapper()).As<IMapper>();

            //WpfStartupService startupService = new WpfStartupService();
            //startupService.ConfigureAppServices(builder);

            builder.AddAppServices();

            return builder.Build();
        }
    }
}
