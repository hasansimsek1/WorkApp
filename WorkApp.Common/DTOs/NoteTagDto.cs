using System;

namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// 
    /// Data transfer object for the Note entity.
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
    /// <para/><see cref="NoteId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Note"/> (Type = <see cref="NoteDto"/>)  (no attribute)
    /// <para/><see cref="TagId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Tag"/> (Type = <see cref="NoteTagDto"/>)  (no attribute)
    /// 
    /// </summary>

    public class NoteTagDto : DtoBase
    {
        /// <summary>
        /// Id of the note that bound to the tag.
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Note entity that bound to the tag.
        /// </summary>
        public NoteDto Note { get; set; }

        /// <summary>
        /// Id of the tag that bound to the note.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Tag entity that bound to the note.
        /// </summary>
        public TagDto Tag { get; set; }
    }
}