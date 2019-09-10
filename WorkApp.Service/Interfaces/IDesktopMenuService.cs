using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Definitions for desktop menu related services.
    /// </summary>
    public interface IDesktopMenuService
    {
        /// <summary>
        /// Contract for retrieving desktop menu items from database.
        /// </summary>
        Task<Result<List<DesktopMenuDto>>> GetDesktopMenuItemsAsync();
    }
}
