namespace WorkApp.UI.Wpf.Interfaces
{
    /// <summary>
    /// Interface for viewmodels that can be bound to content of the drawer component in the UI. 
    /// It's being used by the dependency injection mechanism. 
    /// 
    /// <para/>
    /// 
    /// Implements : IViewModel 
    /// 
    /// <para/>
    /// 
    /// Does not define any elements itself but gets the following methods from IViewModel 
    /// <para />
    /// Task LoadAsync();
    /// </summary>
    public interface IDrawerViewModel : IViewModel
    {
    }
}
