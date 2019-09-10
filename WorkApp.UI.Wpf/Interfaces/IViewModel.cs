using System.Threading.Tasks;

namespace WorkApp.UI.Wpf.Interfaces
{
    /// <summary>
    /// Base interface for ViewModel classes. Defines the following elements :
    /// 
    /// <para/>
    /// 
    /// Methods : 
    /// Task LoadASync(); 
    /// 
    /// <para/>
    /// 
    /// <para>
    /// Properties :  
    /// 
    /// </para>
    /// 
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Classes that implement IViewModel interface must be able to load its requirements.
        /// </summary>
        Task LoadAsync();
    }
}
