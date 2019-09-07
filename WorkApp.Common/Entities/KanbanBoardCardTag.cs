namespace WorkApp.Common.Entities
{
    public class KanbanBoardCardTag : EntityBase
    {
        public int CardId { get; set; }
        public KanbanBoardCard Card { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
