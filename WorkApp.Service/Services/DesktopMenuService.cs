using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.DataAccess.Entities;
using WorkApp.Respository.Interfaces;
using WorkApp.Service.Interfaces;

namespace WorkApp.Service.Services
{
    /// <summary>
    /// Implementation of <see cref="IDesktopMenuService"/>
    /// </summary>
    public class DesktopMenuService : IDesktopMenuService
    {
        private readonly ICrudRepository<DesktopMenu, DesktopMenuDto> _desktopMenuRepository;

        public DesktopMenuService(ICrudRepository<DesktopMenu, DesktopMenuDto> crudRepository)
        {
            _desktopMenuRepository = crudRepository;
        }

        /// <summary>
        /// Retrieves menu items that will be shown on the desktop application.
        /// </summary>
        public async Task<Result<List<DesktopMenuDto>>> GetDesktopMenuItemsAsync()
        {
            return await _desktopMenuRepository.GetAsync();
        }
    }
}
