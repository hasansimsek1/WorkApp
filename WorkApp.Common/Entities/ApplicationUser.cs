using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WorkApp.Common.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ToDo> ToDoes { get; set; }

        public ICollection<KanbanBoard> KanbanBoards { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
