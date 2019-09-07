using System.Collections.Generic;
using WorkApp.Common.DTOs;
using WorkApp.UI.AspNetCoreMvc.Controllers;

namespace WorkApp.UI.AspNetCoreMvc.ViewModels
{
    /// <summary>
    /// Data transfer object that carries needed information from <see cref="DashboardController"/> to the Index view of the dashboard.
    /// </summary>
    public class DashboardViewModel
    {
        /// <summary>
        /// Total count of kanban boards that belong to the user.
        /// </summary>
        public int TotalKanbanBoardCount { get; set; }

        /// <summary>
        /// Last edited kanban board by the user.
        /// </summary>
        public KanbanBoardDto LastEditedKanbanBoard { get; set; }

        /// <summary>
        /// Completed todoes count of the user.
        /// </summary>
        public int CompletedToDoCount { get; set; }

        /// <summary>
        /// Incompleted todoes count of the user.
        /// </summary>
        public int IncompleteToDoCount { get; set; }

        /// <summary>
        /// Today's todoes of the user 
        /// </summary>
        public List<ToDoDto> ToDoesOfToday { get; set; }

        /// <summary>
        /// Count of the notes of the user.
        /// </summary>
        public int TotalNoteCount { get; set; }

        /// <summary>
        /// Last edited note by the user.
        /// </summary>
        public NoteDto LastEditedNote { get; set; }
    }
}
