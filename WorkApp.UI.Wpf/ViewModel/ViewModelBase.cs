using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace WorkApp.UI.Wpf.ViewModel
{
    /// <summary>
    /// Base viewmodel class. 
    /// Implements INotifyPropertyChanged interface.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Get called by property setters when a change occurs.
        /// </summary>
        /// <param name="propertyName">Name of the property that calls this method. This parameter is optained automatically by <see cref="CallerMemberNameAttribute"/> when not assigned.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
