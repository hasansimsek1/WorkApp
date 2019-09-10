using Autofac;
using System.Windows;
using WorkApp.UI.Wpf.Startup;


namespace WorkApp.UI.Wpf
{
    public partial class App : Application
    {
        /// <summary>
        /// Beginning of the WPF app that fires MainWindow. 
        /// Also dependency resolver runs in this method.
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }
    }
}
