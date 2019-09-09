using System;
using System.Collections.Generic;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// Tag entity that is being used by the persistence mechanism.
    /// <para/>
    /// 
    /// Inherits from : <see cref="EntityBase"/>
    /// 
    /// <para/>
    /// 
    /// Properties :
    /// <para/><see cref="EntityBase.Id"/> (Type = <see cref="int"/>) (default value = 0) (no attributes)
    /// <para/><see cref="EntityBase.AddedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="EntityBase.ModifiedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="EntityBase.IsDeleted"/> (Type = <see cref="bool"/>) (default value = <see cref="false"/>) (no attributes)
    /// 
    /// <para/><see cref="Name"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Notes"/> (Type = <see cref="ICollection{T}"/> of <see cref="NoteTag"/>)  (no attribute)
    /// <para/><see cref="KanbanBoardCards"/> (Type = <see cref="ICollection{T}"/> of <see cref="KanbanBoardCardTag"/>)  (no attribute)
    /// 
    /// </summary>

    public class Tag : EntityBase
    {
        /// <summary>
        /// Name of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Notes that bound to the tag.
        /// </summary>
        public ICollection<NoteTag> Notes { get; set; }

        /// <summary>
        /// Kanban board cards that bound to the tag.
        /// </summary>
        public ICollection<KanbanBoardCardTag> KanbanBoardCards { get; set; }
    }
}
