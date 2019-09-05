using System.Collections.Generic;

namespace WorkApp.Common.Entities
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }

        public ICollection<NoteTag> Notes { get; set; }

        public ICollection<KanbanBoardCardTag> KanbanBoardCards { get; set; }
    }
}
