using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class ApplicationUserDto : IdentityUser
    {
        public ICollection<ToDo> ToDoes { get; set; }

        public ICollection<KanbanBoard> KanbanBoards { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
