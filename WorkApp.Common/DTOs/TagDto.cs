using System;
using System.Collections.Generic;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// 
    /// Data transfer object for the Tag entity.
    /// 
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
    /// <para/><see cref="Notes"/> (Type = <see cref="ICollection{T}"/> of <see cref="NoteTagDto"/>)  (no attribute)
    /// <para/><see cref="KanbanBoardCards"/> (Type = <see cref="ICollection{T}"/> of <see cref="KanbanBoardCardTagDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class TagDto : DtoBase
    {
        /// <summary>
        /// Name of the tag.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Notes that bound to the tag.
        /// </summary>
        public ICollection<NoteTagDto> Notes { get; set; }

        /// <summary>
        /// Kanban board cards that bound to the tag.
        /// </summary>
        public ICollection<KanbanBoardCardTagDto> KanbanBoardCards { get; set; }
    }
}
