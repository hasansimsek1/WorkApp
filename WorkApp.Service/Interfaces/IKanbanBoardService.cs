using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    public interface IKanbanBoardService : IService
    {
        Task<Result<int>> GetTotalKanbanBoardCountAsync(string userId);
        Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardAsync(string userId);
        Task<Result<IEnumerable<KanbanBoardDto>>> GetAllAsync(string userId);
        Task<Result<KanbanBoardDto>> AddAsync(KanbanBoardDto newKanban);
        Task<Result<KanbanBoardDto>> GetByIdAsync(int Id);
    }
}
