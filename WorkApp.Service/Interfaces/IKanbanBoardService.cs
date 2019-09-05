using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;

namespace WorkApp.Service.Interfaces
{
    public interface IKanbanBoardService : IService
    {
        Task<Result<int>> GetTotalKanbanBoardCountAsync();
        Task<Result<KanbanBoardDto>> GetLastEditedKanbanBoardAsync();
        Task<Result<IEnumerable<KanbanBoardDto>>> GetAllAsync();
        Task<Result<KanbanBoardDto>> AddAsync(KanbanBoardDto newKanban);
        Task<Result<KanbanBoardDto>> GetByIdAsync(int Id);
    }
}
