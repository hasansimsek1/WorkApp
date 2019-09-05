using System.Threading.Tasks;
using WorkApp.UI.Wpf.Interfaces;


/// <summary>
/// 
/// </summary>
namespace WorkApp.UI.Wpf.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        public IDrawerViewModel DrawerViewModel { get; }
        public IToDoViewModel ToDoViewModel { get; }

        /// <summary>
        /// Initializes services and sub-viewmodels.
        /// </summary>
        public MainViewModel(
            IDrawerViewModel  drawerViewModel,
            IToDoViewModel    toDoViewModel)
        {
            DrawerViewModel = drawerViewModel;
            ToDoViewModel = toDoViewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task LoadAsync()
        {
            await DrawerViewModel.LoadAsync();
            await ToDoViewModel.LoadAsync();
        }
    }
}
