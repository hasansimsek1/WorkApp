using System.Collections.Generic;
using WorkApp.Common.Entities;

namespace WorkApp.Common.DTOs
{
    public class KanbanBoardDto : DtoBase
    {
        public string Name { get; set; }

        public virtual ICollection<KanbanBoardColumn> Columns { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
