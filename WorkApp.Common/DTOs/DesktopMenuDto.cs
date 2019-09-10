namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the DesktopMenu entity.
    /// 
    /// <para/>
    /// 
    /// Inherits from : <see cref="DtoBase"/>
    /// 
    /// <para/>
    /// 
    /// Properties :
    /// <para/><see cref="DtoBase.Id"/> (Type = <see cref="int"/>) (default value = 0) (no attributes)
    /// <para/><see cref="DtoBase.IsDeleted"/> (Type = <see cref="bool"/>) (default value = <see cref="false"/>) (no attributes)
    /// <para/><see cref="DtoBase.AddedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="DtoBase.ModifiedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// 
    /// <para/><see cref="Name"/> (Type = <see cref="string"/>) (no attributes)
    /// <para/><see cref="Order"/> (Type = <see cref="int"/> (no attributes)
    /// <para/><see cref="IsVisible"/> (Type = <see cref="bool"/> (no attributes)
    /// 
    /// </summary>

    public class DesktopMenuDto : DtoBase
    {
        /// <summary>
        /// Name of the desktop UI menu item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Order of the desktop UI menu item in the list.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Visibility status of the desktop menu item.
        /// </summary>
        public bool IsVisible { get; set; }
        
    }
}
