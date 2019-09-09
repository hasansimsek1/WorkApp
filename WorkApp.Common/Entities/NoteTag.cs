using System;

namespace WorkApp.Common.Entities
{
    /// <summary>
    /// NoteTag entity that is being used by the persistence mechanism.
    /// It is a "join class" between Note and Tag entities to abstract many-to-many relationship between these two tables.
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
    /// <para/><see cref="NoteId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Note"/> (Type = <see cref="{Note}"/> entity)  (no attribute)
    /// <para/><see cref="TagId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Tag"/> (Type = <see cref="NoteTag"/>)  (no attribute)
    /// 
    /// </summary>

    public class NoteTag : EntityBase
    {
        /// <summary>
        /// Id of the note that bound to the tag.
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Note entity that bound to the tag.
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        /// Id of the tag that bound to the note.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Tag entity that bound to the note.
        /// </summary>
        public Tag Tag { get; set; }
    }
}
