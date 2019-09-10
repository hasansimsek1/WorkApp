namespace WorkApp.UI.Wpf.Interfaces
{
    /// <summary>
    /// Interface for viewmodel classes that can be bound to ToDo user component. 
    /// It's being used by the dependency injection mechanism to capture right class at runtime.  
    /// 
    /// <para/>
    /// 
    /// Implements : IViewModel 
    /// 
    /// <para />
    /// 
    /// Does not define any elements itself but gets the following methods from <see cref="IViewModel"/>  
    /// <para />
    /// Task LoadAsync();
    /// </summary>
    public interface IToDoViewModel : IViewModel
    {
    }
}
