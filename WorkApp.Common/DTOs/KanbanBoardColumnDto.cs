using System;
using System.Collections.Generic;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the KanbanBoardColumn entity.
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
    /// <para/><see cref="Order"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Cards"/> (Type = <see cref="ICollection{KanbanBoardCardDto}"/> of <see cref="KanbanBoardCardDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardColumnDto : DtoBase
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
        public virtual ICollection<KanbanBoardCardDto> Cards { get; set; }
    }
}
