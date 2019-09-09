using System.Collections.Generic;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;

namespace WorkApp.Service.Interfaces
{
    /// <summary>
    /// Definitions of operations that consumed by the note taking feature of the app.
    /// </summary>
    public interface INoteService : IService
    {
        /// <summary>
        /// Retrieves total note count of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<int>> GetTotalNoteCountOfUserAsync(string userId);

        /// <summary>
        /// Retrieves last edited note of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<NoteDto>> GetLastEditedNoteOfUserAsync(string userId);

        /// <summary>
        /// Retrieves all note records of the user.
        /// </summary>
        /// <param name="userId">Id of the application user.</param>
        Task<Result<List<NoteDto>>> GetByUserId(string userId);
    }
}
