using System;
using WorkApp.DataAccess.Entities;

namespace WorkApp.DataAccess.Entities
{
    /// <summary>
    /// KanbanBoardCardTag entity that is being used by the persistence mechanism.
    /// It is a "join class" between KanbanBoardCard and Tag entities to abstract many-to-many relationship between these two tables.
    /// 
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
    /// <para/><see cref="CardId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="TagId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Card"/> (Type = <see cref="KanbanBoardCard"/>)  (no attribute)
    /// <para/><see cref="Tag"/> (Type = <see cref="Entities.Tag"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardCardTag : EntityBase
    {
        /// <summary>
        /// Id of the kanban board card that bound to the tag.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Kanban board card that bound to the tag.
        /// </summary>
        public KanbanBoardCard Card { get; set; }

        /// <summary>
        /// Id of the tag that bound to the kanban board card.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Tag that bound to the kanban board card.
        /// </summary>
        public Tag Tag { get; set; }
    }
}
