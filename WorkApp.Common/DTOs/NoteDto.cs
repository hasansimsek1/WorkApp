using System.Collections.Generic;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// Data transfer object for the Note entity.
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
    /// <para/><see cref="Tags"/> (Type = <see cref="ICollection{NoteTagDto}"/> of <see cref="NoteTagDto"/>)  (no attribute)
    /// <para/><see cref="UserId"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="User"/> (Type = <see cref="ApplicationUserDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class NoteDto : DtoBase
    {
        /// <summary>
        /// Title of the note.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content of the note.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Tags that bound to the note.
        /// </summary>
        public virtual ICollection<NoteTagDto> Tags { get; set; }

        /// <summary>
        /// Id of the note's user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User of the note.
        /// </summary>
        public ApplicationUserDto User { get; set; }
    }
}
