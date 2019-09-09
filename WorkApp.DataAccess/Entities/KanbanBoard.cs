using System;
using System.Collections.Generic;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// KanbanBoard entity that is being used by the persistence mechanism.
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
    /// <para/><see cref="UserId"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="User"/> (Type = <see cref="ApplicationUser"/>)  (no attribute)
    /// <para/><see cref="Columns"/> (Type = <see cref="ICollection{KanbanBoardColumn}"/> of <see cref="KanbanBoardColumn"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoard : EntityBase
    {
        /// <summary>
        /// Name of the kanban board.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Columns that bound to the kanban board.
        /// </summary>
        public virtual ICollection<KanbanBoardColumn> Columns { get; set; }

        /// <summary>
        /// User Id of the kanban board.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User of the kanban board.
        /// </summary>
        public ApplicationUser User { get; set; }
    }
}
