using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    public interface INoteService : IService
    {
        Task<Result<int>> GetTotalNoteCountAsync(string userId);
        Task<Result<NoteDto>> GetLastEditedNoteAsync(string userId);
        Task<Result<IEnumerable<NoteDto>>> GetAllAsync(string userId);
    }
}
