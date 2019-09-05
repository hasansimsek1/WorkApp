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
        Task<Result<int>> GetTotalNoteCountAsync();
        Task<Result<NoteDto>> GetLastEditedNoteAsync();
        Task<Result<IEnumerable<NoteDto>>> GetAllAsync();
    }
}
