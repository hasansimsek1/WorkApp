using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class TagDto : DtoBase
    {
        public string Name { get; set; }

        public ICollection<NoteTag> Notes { get; set; }

        public ICollection<KanbanBoardCardTag> KanbanBoardCards { get; set; }
    }
}
