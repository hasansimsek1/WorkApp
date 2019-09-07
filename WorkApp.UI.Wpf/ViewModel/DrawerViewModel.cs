using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;
using WorkApp.UI.Wpf.Interfaces;

namespace WorkApp.UI.Wpf.ViewModel
{
    /// <summary>
    /// Viewmodel of the drawer component of the WPF material UI. 
    /// Gets menu items from service layer and binds to the UI.
    /// </summary>
    public class DrawerViewModel : ViewModelBase, IDrawerViewModel
    {
        private ICrudService<DesktopMenu> _service;

        /// <summary>
        /// Dependency injector injects the corresponding ICrudService<DesktopMenu> service class via this constructor.
        /// Also initializes the Menu observable collection of <see cref="DesktopMenu"/>.
        /// </summary>
        public DrawerViewModel(ICrudService<DesktopMenu> service)
        {
            Menu = new ObservableCollection<DesktopMenu>();
            _service = service;
        }

        /// <summary>
        /// Responsible of getting menu items from service layer asynchronously. Then it fills the Menu property of this class.
        /// </summary>
        public async Task LoadAsync()
        {
            var result = await _service.GetAllAsync();

            if(result.HasError)
            {
                System.Windows.Forms.MessageBox.Show("An error has occured while getting menu items from database");
                return;
            }

            foreach (var menuItem in result.Data)
            {
                Menu.Add(menuItem);
            }
        }

        /// <summary>
        /// Keeps the menu items that are bound to the drawer component in the UI.
        /// </summary>
        public ObservableCollection<DesktopMenu> Menu { get; set; }
        
    }
}
