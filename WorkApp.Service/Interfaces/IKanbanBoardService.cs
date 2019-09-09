using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Definitions of operations that consumed by the kanban board feature of the app.
    /// </summary>
    public interface IKanbanBoardService : IService
    {
        /// <summary>
        /// Gets all kanban board records
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<KanbanBoardDto>>> GetAllAsync();

        /// <summary>
        /// Gets the kanban board with the specified Id.
        /// </summary>
        /// <param name="Id">Id of the kanban board.</param>
        Task<Result<KanbanBoardDto>> GetByIdAsync(int Id);

        /// <summary>
        /// Retrieves all kanban board records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<KanbanBoardDto>>> GetByUserIdAsync(string userId);

        /// <summary>
        /// Retrieves total kanban board count.
        /// </summary>
        Task<Result<int>> GetTotalKanbanBoardCountAsync();

        /// <summary>
        /// Retrieves total kanban board count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<int>> GetTotalKanbanBoardCountOfUserAsync(string userId);

        /// <summary>
        /// Gets last edited kanban board by the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardOfUserAsync(string userId);



        /// <summary>
        /// Adds new kanban board.
        /// </summary>
        Task<Result<KanbanBoardDto>> AddAsync(KanbanBoardDto kanbanBoardDto);

        /// <summary>
        /// Updates the kanban board record.
        /// </summary>
        Task<Result<KanbanBoardDto>> UpdateAsync(KanbanBoardDto kanbanBoardDto);

        /// <summary>
        /// Soft-deletes the kanban board record.
        /// </summary>
        Task<Result<KanbanBoardDto>> DeleteAsync(KanbanBoardDto kanbanBoardDto);

    }
}
