using System;
using System.Collections.Generic;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the KanbanBoardCard entity.
    /// <para/>
    /// 
    /// Inherits from : <see cref="DtoBase"/>
    /// 
    /// <para/>
    /// 
    /// Properties :
    /// <para/><see cref="DtoBase.Id"/> (Type = <see cref="int"/>) (default value = 0) (no attributes)
    /// <para/><see cref="DtoBase.AddedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="DtoBase.ModifiedDate"/> (Type = <see cref="DateTime"/>) (default value = <see cref="DateTime.Now"/>) (no attributes)
    /// <para/><see cref="DtoBase.IsDeleted"/> (Type = <see cref="bool"/>) (default value = <see cref="false"/>) (no attributes)
    /// 
    /// <para/><see cref="Title"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Content"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Order"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Tags"/> (Type = <see cref="ICollection{KanbanBoardCardTagDto}"/> of <see cref="KanbanBoardCardTagDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardCardDto : DtoBase
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
        public virtual ICollection<KanbanBoardCardTagDto> Tags { get; set; }
    }
}
