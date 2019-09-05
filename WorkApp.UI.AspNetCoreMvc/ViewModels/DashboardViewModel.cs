using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkApp.Common.DTOs;
using WorkApp.Common.Entities;

namespace WorkApp.UI.AspNetCoreMvc.ViewModels
{
    public class DashboardViewModel
    {
        public int TotalKanbanBoardCount { get; set; }
        public KanbanBoardDto LastEditedKanbanBoard { get; set; }

        public int CompletedToDoCount { get; set; }
        public int IncompleteToDoCount { get; set; }
        public List<ToDoDto> ToDoesOfToday { get; set; }

        public int TotalNoteCount { get; set; }
        public NoteDto LastEditedNote { get; set; }
    }
}
