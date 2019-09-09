using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    public interface IDesktopMenuService
    {
        Task<Result<List<DesktopMenuDto>>> GetDesktopMenuItemsAsync();
    }
}
