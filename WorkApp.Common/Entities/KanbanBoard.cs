using System;
using System.Collections.Generic;
using System.Text;

namespace WorkApp.Common.Entities
{
    public class KanbanBoard : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<KanbanBoardColumn> Columns { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
