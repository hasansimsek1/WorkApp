using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class KanbanBoardCardDto : DtoBase
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int Order { get; set; }

        public virtual ICollection<KanbanBoardCardTag> Tags { get; set; }
    }
}
