using System;
using System.Collections.Generic;
using System.Text;

namespace WorkApp.Common.Entities
{
    public class KanbanBoardColumn : EntityBase
    {
        public string Title { get; set; }

        public int Priority { get; set; }

        public virtual ICollection<KanbanBoardCard> Cards { get; set; }
    }
}
