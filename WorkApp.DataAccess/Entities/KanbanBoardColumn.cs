using System;
using System.Collections.Generic;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// KanbanBoardColumn entity that is being used by the persistence mechanism.
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
    /// <para/><see cref="Title"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Order"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Cards"/> (Type = <see cref="ICollection{KanbanBoardCard}"/> of <see cref="KanbanBoardCard"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardColumn : EntityBase
    {
        /// <summary>
        /// Title of the kanban board column
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Order of the kanban board column on the kanban board.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Kanban board cards bound to the kanban board column.
        /// </summary>
        public virtual ICollection<KanbanBoardCard> Cards { get; set; }
    }
}
