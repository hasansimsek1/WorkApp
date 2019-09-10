using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using WorkApp.DataAccess.Interfaces;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// User entity of the app. 
    /// As this project uses Identity Core, this class inherits from <see cref="IdentityUser"/>.
    /// 
    /// <para/>
    /// 
    /// Implements : <see cref="IEntity"/>
    /// 
    /// <para/>
    /// 
    /// Properties that <see cref="ApplicationUser"/> extends <see cref="IdentityUser"/> : 
    /// <para/><see cref="ToDoes"/> (Type = <see cref="ICollection{TEntity}"/> of <see cref="ToDo"/>  (no attribute)
    /// <para/><see cref="KanbanBoards"/> (Type = <see cref="ICollection{TEntity}"/> of <see cref="KanbanBoard"/> (no attribute)
    /// <para/><see cref="Notes"/> (Type = <see cref="ICollection{TEntity}"/> of <see cref="Note"/> (no attribute)
    /// 
    /// </summary>

    public class ApplicationUser : IdentityUser, IEntity
    {
        public ICollection<ToDo> ToDoes { get; set; }

        public ICollection<KanbanBoard> KanbanBoards { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
