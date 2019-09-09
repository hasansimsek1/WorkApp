using System;
using System.Collections.Generic;

namespace WorkApp.Common.Entities
{
    /// <summary>
    /// Note entity that is being used by the persistence mechanism.
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
    /// <para/><see cref="Title"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Content"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="Tags"/> (Type = <see cref="ICollection{NoteTag}"/> of <see cref="NoteTag"/>)  (no attribute)
    /// <para/><see cref="UserId"/> (Type = <see cref="string"/>)  (no attribute)
    /// <para/><see cref="User"/> (Type = <see cref="ApplicationUser"/>)  (no attribute)
    /// 
    /// </summary>

    public class Note : EntityBase
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
        public virtual ICollection<NoteTag> Tags { get; set; }

        /// <summary>
        /// Id of the note's user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User of the note.
        /// </summary>
        public ApplicationUser User { get; set; }
    }
}
