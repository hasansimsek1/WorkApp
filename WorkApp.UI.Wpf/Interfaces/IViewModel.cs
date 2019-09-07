using System.Threading.Tasks;

namespace WorkApp.UI.Wpf.Interfaces
{
    /// <summary>
    /// <para>   
    /// Base interface for ViewModel classes. Defines the following elements :
    /// </para>
    /// 
    /// <para/>
    /// 
    /// <para>
    /// Methods  :   
    /// Task LoadASync(); 
    /// </para>
    /// 
    /// <para/>
    /// 
    /// <para>
    /// Properties  :  
    /// 
    /// </para>
    /// 
    /// </summary>
    public interface IViewModel
    {
        /// <summary>
        /// Classes that implement IViewModel interface must be able to load its requirements.
        /// </summary>
        /// <returns></returns>
        Task LoadAsync();
    }
}
