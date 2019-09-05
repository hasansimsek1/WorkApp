using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class KanbanBoardColumnDto : DtoBase
    {
        public string Title { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<KanbanBoardCard> Cards { get; set; }
    }
}
