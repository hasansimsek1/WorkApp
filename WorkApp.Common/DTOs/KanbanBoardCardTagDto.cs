namespace WorkApp.Common.DTOs
{
    /// <summary>
    /// 
    /// Data transfer object for the KanbanBoardCardTag entity.
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
    /// <para/><see cref="CardId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="TagId"/> (Type = <see cref="int"/>)  (no attribute)
    /// <para/><see cref="Card"/> (Type = <see cref="KanbanBoardCardDto"/>)  (no attribute)
    /// <para/><see cref="Tag"/> (Type = <see cref="TagDto"/>)  (no attribute)
    /// 
    /// </summary>
    
    public class KanbanBoardCardTagDto : DtoBase
    {
        /// <summary>
        /// Id of the kanban board card that bound to the tag.
        /// </summary>
        public int CardId { get; set; }

        /// <summary>
        /// Kanban board card that bound to the tag.
        /// </summary>
        public KanbanBoardCardDto Card { get; set; }

        /// <summary>
        /// Id of the tag that bound to the kanban board card.
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Tag that bound to the kanban board card.
        /// </summary>
        public TagDto Tag { get; set; }
    }
}
