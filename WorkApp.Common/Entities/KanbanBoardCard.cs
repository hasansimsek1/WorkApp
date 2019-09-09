using System;
using System.Collections.Generic;

namespace WorkApp.Common.Entities
{
    /// <summary>
    /// KanbanBoardCard entity that is being used by the persistence mechanism.
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
    /// <para/><see cref="Content"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Order"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Tags"/> (Type = <see cref="ICollection{KanbanBoardCardTag}"/> of <see cref="KanbanBoardCardTag"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardCard : EntityBase
    {
        /// <summary>
        /// Title of the kanban board card.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content of the kanban board card.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Order of the kanban board card on the kanban board column.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Collection of tags bound to the kanban board card.
        /// </summary>
        public virtual ICollection<KanbanBoardCardTag> Tags { get; set; }

    }
}
