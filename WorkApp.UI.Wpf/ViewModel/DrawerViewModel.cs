using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WorkApp.Common.Entities;
using WorkApp.Service.Interfaces;
using WorkApp.UI.Wpf.Interfaces;

namespace WorkApp.UI.Wpf.ViewModel
{
    public class DrawerViewModel : ViewModelBase, IDrawerViewModel
    {
        private ICrudService<DesktopMenu> _service;

        public DrawerViewModel(ICrudService<DesktopMenu> service)
        {
            Menu = new ObservableCollection<DesktopMenu>();
            _service = service;
        }

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

        public ObservableCollection<DesktopMenu> Menu { get; set; }
        
    }
}
