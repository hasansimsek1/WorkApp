using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WorkApp.Common.Interfaces;

namespace WorkApp.Common.Entities
{
    /// <summary>
    /// User entity of the app. 
    /// As this project uses Identity Core, this class inherits from <see cref="IdentityUser"/>.
    /// 
    /// <para/>
    /// 
    /// Properties that <see cref="ApplicationUser"/> extends <see cref="IdentityUser"/> : 
    /// <para/><see cref="ToDoes"/> (Type = <see cref="ICollection{T}"/> of <see cref="Todo"/>  (no attribute)
    /// <para/><see cref="KanbanBoards"/> (Type = <see cref="ICollection{T}"/> of <see cref="KanbanBoard"/> (no attribute)
    /// <para/><see cref="Notes"/> (Type = <see cref="ICollection{T}"/> of <see cref="Note"/> (no attribute)
    /// 
    /// </summary>
    
    public class ApplicationUser : IdentityUser, IEntity
    {
        public ICollection<ToDo> ToDoes { get; set; }

        public ICollection<KanbanBoard> KanbanBoards { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
