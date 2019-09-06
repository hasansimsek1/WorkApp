using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;

namespace WorkApp.Service.Interfaces
{
    public interface INoteService : IService
    {
        Task<Result<int>> GetTotalNoteCountAsync(string userId);
        Task<Result<NoteDto>> GetLastEditedNoteAsync(string userId);
        Task<Result<IEnumerable<NoteDto>>> GetAllAsync(string userId);
    }
}
