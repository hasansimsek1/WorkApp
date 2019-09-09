using System.Collections.Generic;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the ApplicationUser entity.
    /// <para/>
    /// Properties :
    /// <para/><see cref="Id"/>             <see cref="string"/> (no attributes)
    /// <para/><see cref="Email"/>          <see cref="string"/> (no attributes)
    /// <para/><see cref="PhoneNumber"/>    <see cref="string"/> (no attributes)
    /// <para/><see cref="ToDoes"/>         <see cref="ICollection{ToDoDto}"/> (no attributes)
    /// <para/><see cref="KanbanBoards"/>   <see cref="ICollection{KanbanBoardDto}"/> (no attributes)
    /// <para/><see cref="Notes"/>          <see cref="ICollection{NoteDto}"/> (no attributes)
    /// </summary>
    public class ApplicationUserDto : IDto
    {
        /// <summary>
        /// Id of the application user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Email of the application user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the application user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Todoes of the application user.
        /// </summary>
        public ICollection<ToDoDto> ToDoes { get; set; }

        /// <summary>
        /// Kanban boards of the application user.
        /// </summary>
        public ICollection<KanbanBoardDto> KanbanBoards { get; set; }

        /// <summary>
        /// Notes of the application user.
        /// </summary>
        public ICollection<NoteDto> Notes { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
