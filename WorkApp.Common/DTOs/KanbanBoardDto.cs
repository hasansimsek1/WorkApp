using System.Collections.Generic;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the KanbanBoard entity.
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
    /// <para/><see cref="Name"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="UserId"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="User"/> (Type = <see cref="ApplicationUserDto"/>)  (no attribute)
    /// <para/><see cref="Columns"/> (Type = <see cref="ICollection{KanbanBoardColumnDto}"/> of <see cref="KanbanBoardColumnDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class KanbanBoardDto : DtoBase
    {
        /// <summary>
        /// Name of the kanban board.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Columns of the kanban board.
        /// </summary>
        public virtual ICollection<KanbanBoardColumnDto> Columns { get; set; }

        /// <summary>
        /// Id of the user that owns the kanban board.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Application user of the kanban board.
        /// </summary>
        public ApplicationUserDto User { get; set; }
    }
}
