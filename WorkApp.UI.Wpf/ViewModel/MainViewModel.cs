using System.Threading.Tasks;
using WorkApp.UI.Wpf.Interfaces;


namespace WorkApp.UI.Wpf.ViewModel
{
    /// <summary>
    /// Viewmodel that is bound to the MainWindow.
    /// Responsible for initializing sub-viewmodels for the MainWindow. 
    /// Used sub-viewmodels are : <para/>
    /// DrawerViewModel, 
    /// ToDoViewModel
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public IDrawerViewModel DrawerViewModel { get; }
        public IToDoViewModel ToDoViewModel { get; }

        /// <summary>
        /// Dependency injection mechanism injects the dependencies of this view-model via this constructor.
        /// </summary>
        public MainViewModel(IDrawerViewModel drawerViewModel, IToDoViewModel toDoViewModel)
        {
            DrawerViewModel = drawerViewModel;
            ToDoViewModel = toDoViewModel;
        }

        /// <summary>
        /// This method loads the relevant methods of the sub-viewmodels. These are DrawerViewModel.LoadAsync(), ToDoViewModel.LoadAsync()
        /// </summary>
        public async Task LoadAsync()
        {
            await DrawerViewModel.LoadAsync();
            await ToDoViewModel.LoadAsync();
        }
    }
}
